namespace Flashcard.Domain.Entities;

public class FlashcardItem
{
    public Guid Id { get; set; }
    public string Word { get; set; } = string.Empty;
    public string Meaning { get; set; } = string.Empty;
    public string? Example { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}