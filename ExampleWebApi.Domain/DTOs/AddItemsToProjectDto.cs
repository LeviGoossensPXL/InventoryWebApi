using System.ComponentModel.DataAnnotations;

namespace ExampleWebApi.Domain.DTOs
{
    public class AddItemsToProjectDto
    {
        [Required]
        public IEnumerable<int> ItemIds { get; set; }
    }
}
