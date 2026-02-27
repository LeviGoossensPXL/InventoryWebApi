namespace ExampleWebApi.Domain.DTOs.Responses;

public class OwnedItemResponseDto
{
    public int Id { get; init; }

    public Guid OwnerId { get; init; }
    public string Name { get; set; }
    public string Brand { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }

    public decimal? Price { get; init; }
    public string? ImageUrl { get; init; }
    public DateTime? AcquiredAt { get; init; }
    public string? Notes { get; init; }

    public List<int> GroupIds { get; set; } = new();
}
