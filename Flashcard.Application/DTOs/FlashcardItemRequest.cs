namespace Flashcard.Application.DTOs;

public class FlashcardItemRequest
{
    public string Word { get; set; } = string.Empty;
    public string Meaning { get; set; } = string.Empty;
    public string? Example { get; set; }
}