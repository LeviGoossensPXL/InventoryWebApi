using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWebApi.Domain.Entities
{
    public class OwnedItem : Item
    {
        public int Id { get; set; }
        public Guid OwnerId { get; set; }
        public User Owner { get; set; }

        public ICollection<GroupOwnedItem> GroupOwnedItems { get; set; } = [];

        public decimal? Price { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? AcquiredAt { get; set; }
        [MaxLength(500)]
        public string? Notes { get; set; }
    }
}
