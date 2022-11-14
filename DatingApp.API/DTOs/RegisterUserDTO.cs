using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.DTOs;

public class RegisterUserDTO
{
    [Required]
    [MaxLength(256)]
    public string Username { get; set; }

    [MaxLength(256)]
    public string Email { get; set; }

    [Required]
    [MaxLength(256)]
    public string Password { get; set; }

    [Required]
    public DateTime? DateOfBirth { get; set; }

    [MaxLength(32)]
    public string KnowAs { get; set; }

    [MaxLength(6)]
    public string Gender { get; set; }

    [MaxLength(256)]
    public string Introduction { get; set; }

    [MaxLength(32)]
    public string City { get; set; }

    [MaxLength(256)]
    public string Avatar { get; set; }
}