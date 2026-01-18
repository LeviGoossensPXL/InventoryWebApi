namespace ExampleWebApi.Domain.DTOs.Responses;

public class GroupResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    // Related IDs only
    public List<int> OwnedItemIds { get; set; } = new();
    public List<int> WishedItemIds { get; set; } = new();
    public List<int> ProjectIds { get; set; } = new();
    public List<Guid> UserIds { get; set; } = new();
}