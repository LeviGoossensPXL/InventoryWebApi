using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWebApi.Domain.Entities
{
    public class OwnedItem
    {
        public int Id { get; set; }
        public Guid OwnerId { get; set; }
        public User Owner { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public DateTime DateTime { get; set; }
        public string Notes { get; set; }
    }
}
