using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.DTOs;

public class AuthUserDTO
{
    [Required]
    [MaxLength(256)]
    public string Username { get; set; }

    [Required]
    [MaxLength(256)]
    public string Password { get; set; }
}