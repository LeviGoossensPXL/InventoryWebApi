namespace ExampleWebApi.Domain.DTOs.Responses;

public class ItemResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    // Lists of related entity IDs
    public List<int> OwnedItemIds { get; set; } = new();
    public List<int> WishedItemIds { get; set; } = new();
    public List<int> ProjectItemIds { get; set; } = new();
}