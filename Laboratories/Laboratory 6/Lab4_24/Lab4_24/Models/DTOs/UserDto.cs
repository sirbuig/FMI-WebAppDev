namespace Lab4_24.Models.DTOs;

public class UserDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Username { get; set; } = default!;
}