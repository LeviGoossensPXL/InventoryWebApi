using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWebApi.Domain.Entities
{
    public class Group
    {
        public int Id { get; set; }

        public ICollection<GroupOwnedItem> GroupOwnedItems { get; set; } = [];
        public ICollection<OwnedItem> OwnedItems { get; set; } = [];

        public ICollection<GroupWishedItem> GroupWishedItems { get; set; } = [];
        public ICollection<WishedItem> WishedItems { get; set; } = [];

        public ICollection<GroupProject> GroupProjects { get; set; } = [];
        public ICollection<Project> Projects { get; set; } = [];

        public ICollection<GroupUser> GroupUsers { get; set; } = [];
        public ICollection<User> Users { get; set; } = [];

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
