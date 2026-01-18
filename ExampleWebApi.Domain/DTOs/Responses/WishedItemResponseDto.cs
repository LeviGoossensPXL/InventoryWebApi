namespace ExampleWebApi.Domain.DTOs.Responses;

public class WishedItemResponseDto
{
    public int Id { get; init; }

    public Guid UserId { get; init; }

    public int ItemId { get; init; }

    public decimal? Price { get; init; }
    public int? Priority { get; init; }

    public List<int> GroupIds { get; init; } = new();
}