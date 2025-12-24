using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ExampleWebApi.Domain.Entities;

public class User : IdentityUser<Guid>
{
    public string NickName { get; set; }
}