using DatingApp.API.Data.Repositories;
using System.Security.Cryptography;
using DatingApp.API.Data.Entities;
using DatingApp.API.Data;
using DatingApp.API.DTOs;
using System.Text;
using AutoMapper;

namespace DatingApp.API.Services;

public class AuthService : IAuthService
{
    private readonly ITokenService _tokenService;
    private readonly IUserRepository _userRepo;
    private readonly IMapper _mapper;
    public AuthService(DataContext context,
                       ITokenService tokenService,
                       IUserRepository userRepo,
                       IMapper mapper)
    {
        _tokenService = tokenService;
        _userRepo = userRepo;
        _mapper = mapper;
    }

    public async Task<string> Login(AuthUserDTO authUserDTO)
    {
        authUserDTO.Username = authUserDTO.Username.ToLower();
        var currentUser = await _userRepo.GetUserByUsername(authUserDTO.Username);
        if (currentUser == null)
        {
            throw new UnauthorizedAccessException("Invalid Username");
        }

        using var hmac = new HMACSHA512(currentUser.PasswordSalt);
        var passwordByte = Encoding.UTF8.GetBytes(authUserDTO.Password);
        var computedHash = hmac.ComputeHash(passwordByte);

        if (!computedHash.SequenceEqual(currentUser.PasswordHashed))
        {
            throw new UnauthorizedAccessException("Invalid Password");
        }
        var token = _tokenService.CreateToken(currentUser);
        return token;
    }

    public async Task<string> Register(RegisterUserDTO registerUserDTO)
    {
        registerUserDTO.Username = registerUserDTO.Username.ToLower();
        if (await _userRepo.GetUserByUsername(registerUserDTO.Username) != null)
        {
            throw new BadHttpRequestException("This username is existing");
        }
        using var hmac = new HMACSHA512();
        var passwordByte = Encoding.UTF8.GetBytes(registerUserDTO.Password);

        var newUser = _mapper.Map<User>(registerUserDTO);
        newUser.PasswordSalt = hmac.Key;
        newUser.PasswordHashed = hmac.ComputeHash(passwordByte);
        newUser.CreatedAt = DateTime.Now;
        newUser.UpdatedAt = null;

        await _userRepo.InsertNewUser(newUser);
        var token = _tokenService.CreateToken(newUser);
        return token;
    }
}