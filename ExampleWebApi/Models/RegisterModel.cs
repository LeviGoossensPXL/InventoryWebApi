using System.ComponentModel.DataAnnotations;

namespace ExampleWebApi.Api.Models;

public class RegisterModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(4)]
    public string Nickname { get; set; }

    [Required]
    [MinLength(6)]
    public string Password { get; set; }
}