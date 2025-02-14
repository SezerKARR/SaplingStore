using System.ComponentModel.DataAnnotations;

namespace SaplingStore.DTOs.Account;

public class RegisterDto
{
    [Required] public required string UserName { get; set; }

    [Required] [EmailAddress] public required string Email { get; set; }

    [Required] public required string Password { get; set; }

    public required string Role { get; set; }
}