using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography;
using DatingApp.API.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using DatingApp.API.Services;
using DatingApp.API.DTOs;
using DatingApp.API.Data;
using System.Text;

namespace DatingApp.API.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly DataContext _context;
    private readonly ITokenService _tokenService;

    public AuthController(DataContext context, ITokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }

    [HttpPost("Register")]
    public IActionResult Register([FromBody] AuthUserDTO authUserDTO)
    {
        if (ModelState.IsValid)
        {
            authUserDTO.Username = authUserDTO.Username.ToLower();
            if (_context.AppUsers.Any(c => c.Username == authUserDTO.Username))
            {
                return BadRequest("This username is existing");
            }
            using var hmac = new HMACSHA512();
            var passwordByte = Encoding.UTF8.GetBytes(authUserDTO.Password);
            var newUser = new User()
            {
                Username = authUserDTO.Username,
                Email = $"{authUserDTO.Username}@gmail.com",
                PasswordSalt = hmac.Key,
                PasswordHashed = hmac.ComputeHash(passwordByte),
            };
            _context.AppUsers.Add(newUser);
            _context.SaveChanges();
            // return Ok(new
            // {
            //     Username = newUser.Username,
            //     Token = _tokenService.CreateToken(newUser)
            // });
            var token = _tokenService.CreateToken(newUser);
            return Ok(token);
        }
        return BadRequest();
    }

    [HttpPost("Login")]
    public IActionResult Login([FromBody] AuthUserDTO authUserDTO)
    {
        authUserDTO.Username = authUserDTO.Username.ToLower();
        var currentUser = _context.AppUsers.FirstOrDefault(c => c.Username == authUserDTO.Username);
        if (currentUser == null)
        {
            return Unauthorized("Invalid Username");
        }

        using var hmac = new HMACSHA512(currentUser.PasswordSalt);
        var passwordByte = Encoding.UTF8.GetBytes(authUserDTO.Password);
        var computedHash = hmac.ComputeHash(passwordByte);

        // for (var i = 0; i < computedHash.Length; i++)
        // {
        //     if (computedHash[i] != currentUser.PasswordHashed[i])
        //     {
        //         return Unauthorized("Invalid Password");
        //     }
        // }

        if (!computedHash.SequenceEqual(currentUser.PasswordHashed))
        {
            return Unauthorized("Invalid Password");
        }

        // return Ok(new
        // {
        //     Username = currentUser.Username,
        //     Token = _tokenService.CreateToken(currentUser)
        // });
        var token = _tokenService.CreateToken(currentUser);
        return Ok(token);
    }

    // [HttpGet]
    // [Authorize]
    // public IActionResult Get()
    // {
    //     return Ok(_context.AppUsers.ToList());
    // }
}