using System.ComponentModel.DataAnnotations;

namespace ExampleWebApi.Domain.DTOs
{
    public class ItemDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
