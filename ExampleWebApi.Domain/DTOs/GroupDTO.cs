using System.ComponentModel.DataAnnotations;

namespace ExampleWebApi.Domain.DTOs
{
    public class GroupDTO
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}