using System.ComponentModel.DataAnnotations;

namespace ExampleWebApi.Domain.DTOs
{
    public class WishedItemDto
    {
        public Guid UserId { get; set; }
        public int ItemId { get; set; }
        public decimal? Price { get; set; }
        public int? Priority { get; set; }
    }
}
