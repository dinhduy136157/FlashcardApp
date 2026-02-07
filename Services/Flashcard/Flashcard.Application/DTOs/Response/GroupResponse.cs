namespace Flashcard.Application.DTOs;

public class GroupResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid UserId { get; set; }
}