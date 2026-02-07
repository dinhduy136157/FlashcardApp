using Flashcard.Domain.Entities;

public class Group
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public ICollection<FlashcardItem> FlashcardItems { get; set; } = new List<FlashcardItem>();
}