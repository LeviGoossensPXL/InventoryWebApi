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
        public ICollection<GroupItem> GroupItems { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
