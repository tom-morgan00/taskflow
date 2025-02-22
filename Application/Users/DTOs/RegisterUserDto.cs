using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Users.DTOs;

public class RegisterUserDto
{
    [Required]
    public string DisplayName { get; set; } = "";
    [Required]
    [EmailAddress]
    public string Email { get; set; } = "";
    [Required]
    public string Password { get; set; } = "";
}
