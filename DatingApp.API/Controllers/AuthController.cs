using Microsoft.AspNetCore.Mvc;
using DatingApp.API.Services;
using DatingApp.API.DTOs;

namespace DatingApp.API.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] AuthUserDTO authUserDTO)
    {
        if (ModelState.IsValid)
        {
            try
            {
                return Ok(await _authService.Login(authUserDTO));
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
        return BadRequest("Model state is invalid");
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserDTO registerUserDTO)
    {
        if (ModelState.IsValid)
        {
            try
            {
                return Ok(await _authService.Register(registerUserDTO));
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        return BadRequest("Model state is invalid");
    }
}