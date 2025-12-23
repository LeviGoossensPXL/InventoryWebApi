using ExampleWebApi.Domain.Entities;

namespace ExampleWebApi.Infrastructure
{
    public static class SeedData
    {
        public static IEnumerable<Item> Items => new List<Item>()
        {
            new Item
            {
                Id = 1,
                Name = "3d printer",
                Image = "https://localhost:7027/images/items/b95db868-ecb5-41f1-8f82-5a8bf520ad66.jpg",
                Brand = "Prusa",
                Type = "CoreOne",
                Price = 1500.00m
            },
            new Item {
                Id = 2,
                Name = "repair toolkit",
                Image = "https://localhost:7027/images/items/c82af8a4-3662-4734-8453-a4e08197efc6.jpg",
                Brand = "iFixIt",
                Type = "pro tech toolkit",
                Price = 77.41m
            },
            new Item {
                Id = 3,
                Name = "monitor arm",
                Image = "https://localhost:7027/images/items/45690b8f-3173-4e74-be8f-c773612046bb.jpg",
                Brand = "Alberenz",
                Type = "single monitorarm Donkergrijs",
                Price = 99.00m
            }
        };

        public static IEnumerable<Project> Projects => new List<Project>
        {
            new Project
            {
                Id = 1,
                Name = "led cube",
                Description = "leds in de vorm van een kubus om mooie effect te tonen door programmatie"
            },
            new Project
            {
                Id = 2,
                Name = "self balancing cube",
                Description = "een kubus die zich zelf kan balanceren op zijn punt"
            }
        };

        public static IEnumerable<Person> Persons => new List<Person>
        {
            new Person
            {
                Id = Guid.NewGuid(),
                UserId = Users.ToList()[0].Id,
                NickName = "dragon"
            },
            new Person
            {
                Id = Guid.NewGuid(),
                UserId = Users.ToList()[1].Id,
                NickName = "loren"
            },
            new Person
            {
                Id = Guid.NewGuid(),
                UserId = Users.ToList()[2].Id,
                NickName = "cyber"
            },
            new Person
            {
                Id = Guid.NewGuid(),
                UserId = Users.ToList()[3].Id,
                NickName = "lord"
            }
        };

        public static IEnumerable<User> Users => new List<User> {
            new User { Id = Guid.Parse("52a28510-1ef3-4e2c-b4ee-3ea66a0f8200"), Email = "levigoossens17@gmail.com", PasswordHash = "password1" },
            new User { Id = Guid.Parse("6c4a1ab1-343e-4e7d-b02d-c06783554445"), Email = "alex22@gmail.com", PasswordHash = "password2" },
            new User { Id = Guid.Parse("5ef92990-dacb-44b5-8d1e-c6ca68d703fb"), Email = "luca33@gmail.com", PasswordHash = "password3" },
            new User { Id = Guid.Parse("f4fdc5c1-bc32-4768-90b5-644ebc069962"), Email = "tom44@gmail.com", PasswordHash = "password4" }
        };

        public static IEnumerable<Group> Groups => new List<Group> {
            new Group
            {
                Id = 1,
                Name = "work",
                Description = "Items used for work, office tasks, or professional activities"
            },
            new Group
            {
                Id = 2,
                Name = "home",
                Description = "Everyday items used around the house"
            },

            new Group
            {
                Id = 3,
                Name = "food",
                Description = "Groceries, pantry items, and consumable food products"
            },
            new Group
            {
                Id = 4,
                Name = "electronics",
                Description = "Electronic devices, gadgets, and accessories"
            },

            new Group
            {
                Id = 5,
                Name = "other",
                Description = "Items that do not fit into any specific category"
            }
        };
    }
}
