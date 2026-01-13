using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public ICollection<GroupOwnedItem> GroupOwnedItems { get; set; } = [];
        public ICollection<Group> Groups { get; set; } = [];

        public decimal? Price { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? AcquiredAt { get; set; }
        [MaxLength(500)]
        public string? Notes { get; set; }
    }
}
