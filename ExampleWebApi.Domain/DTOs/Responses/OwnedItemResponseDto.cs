namespace ExampleWebApi.Domain.DTOs.Responses;

public class OwnedItemResponseDto
{
    public int Id { get; init; }

    public Guid OwnerId { get; init; }
    public int ItemId { get; init; }

    public decimal? Price { get; init; }
    public string? ImageUrl { get; init; }
    public DateTime? AcquiredAt { get; init; }
    public string? Notes { get; init; }

    public List<int> GroupIds { get; set; } = new();
}
