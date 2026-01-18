using System.ComponentModel.DataAnnotations;

namespace ExampleWebApi.Domain.DTOs
{
    public class GroupDto
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}