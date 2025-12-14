using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ExampleWebApi.Domain.Entities;

public class User : IdentityUser<Guid>
{
    [Required]
    public string NickName { get; set; }
}