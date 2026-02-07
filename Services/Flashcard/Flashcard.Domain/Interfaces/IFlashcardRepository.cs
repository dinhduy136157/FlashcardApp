using Flashcard.Domain.Entities;

namespace Flashcard.Domain.Interfaces;

public interface IFlashcardRepository
{
    Task<IEnumerable<Entities.FlashcardItem>> GetAllAsync();
    Task<Entities.FlashcardItem?> GetByIdAsync(Guid id);
    Task AddAsync(Entities.FlashcardItem flashcard);
    Task AddRangeAsync(IEnumerable<FlashcardItem> entities);
    Task<IEnumerable<FlashcardItem>> GetByGroupIdAsync(Guid groupId);
}