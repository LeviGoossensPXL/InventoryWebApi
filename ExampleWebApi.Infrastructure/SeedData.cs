using ExampleWebApi.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleWebApi.Infrastructure
{
    public static class SeedData
    {
        public struct SeedUser
        {
            public Guid Id;
            public string Email;
            public string Password;
        }
        
        public static IEnumerable<SeedUser> SeedUsers => new List<SeedUser> {
            new SeedUser { Id = Guid.Parse("52a28510-1ef3-4e2c-b4ee-3ea66a0f8200"), Email = "levi1@gmail.com", Password = "password1" },
            new SeedUser { Id = Guid.Parse("6c4a1ab1-343e-4e7d-b02d-c06783554445"), Email = "alex2@gmail.com", Password = "password2" },
            new SeedUser { Id = Guid.Parse("5ef92990-dacb-44b5-8d1e-c6ca68d703fb"), Email = "luca3@gmail.com", Password = "password3" },
            new SeedUser { Id = Guid.Parse("f4fdc5c1-bc32-4768-90b5-644ebc069962"), Email = "tom4@gmail.com", Password = "password4" }
        };
    }
}
