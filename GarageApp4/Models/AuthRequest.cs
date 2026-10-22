using System.ComponentModel.DataAnnotations;

namespace GarageApp4.Models;

public class AuthRequest
{
    [Required, MinLength(3)]
    public string Username { get; set; } = string.Empty;

    [Required, MinLength(6)]
    public string Password { get; set; } = string.Empty;
}