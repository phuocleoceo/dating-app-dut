using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.DTOs;

public class UserTokenDTO
{
    public string Username { get; set; }
    public string Token { get; set; }
}