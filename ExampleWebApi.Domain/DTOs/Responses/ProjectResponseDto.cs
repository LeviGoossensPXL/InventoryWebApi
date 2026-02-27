namespace ExampleWebApi.Domain.DTOs.Responses;

public class ProjectResponseDto
{
    public int Id { get; init; }

    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;

    // Flatten relationships
    public IReadOnlyCollection<int> GroupIds { get; init; } = Array.Empty<int>();
    public IReadOnlyCollection<int> ItemIds { get; init; } = Array.Empty<int>();
}