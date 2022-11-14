using DatingApp.API.DTOs;

namespace DatingApp.API.Services;

public interface IAuthService
{
    Task<string> Login(AuthUserDTO authUserDTO);

    Task<string> Register(RegisterUserDTO registerUserDTO);
}