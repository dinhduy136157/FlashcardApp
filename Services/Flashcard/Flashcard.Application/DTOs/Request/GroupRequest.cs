namespace Flashcard.Application.DTOs;

public class GroupRequest
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid UserId { get; set; }
}