using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWebApi.Domain.Entities
{
    public class Person
    {
        public Guid Id { get; set; }

        public string NickName { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
