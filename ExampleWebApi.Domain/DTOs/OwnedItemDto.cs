using System.ComponentModel.DataAnnotations;

namespace ExampleWebApi.Domain.DTOs
{
    public class OwnedItemDto
    {
        public Guid OwnerId { get; set; }
        // public string OwnerName { get; set; } // Simplified User reference
        public int ItemId { get; set; }
        // public string ItemName { get; set; } // Simplified Item reference
        public decimal? Price { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? AcquiredAt { get; set; }
        [MaxLength(500)]
        public string? Notes { get; set; }
    }
}
