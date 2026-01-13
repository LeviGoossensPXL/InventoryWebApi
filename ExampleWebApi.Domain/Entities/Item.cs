using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWebApi.Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public ICollection<GroupItem> GroupItems { get; set; }
        public ICollection<OwnedItem> OwnedItems { get; set; } = new List<OwnedItem>();
        public ICollection<WishedItem> WishedItems { get; set; } = new List<WishedItem>();
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
    }
}
