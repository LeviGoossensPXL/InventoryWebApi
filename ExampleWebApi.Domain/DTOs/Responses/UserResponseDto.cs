namespace ExampleWebApi.Domain.DTOs.Responses;

public class UserResponseDto
{
    public Guid UserId { get; set; }
    public string NickName { get; set; }

    public string Email { get; set; }

    public string? PhoneNumber { get; set; }
}