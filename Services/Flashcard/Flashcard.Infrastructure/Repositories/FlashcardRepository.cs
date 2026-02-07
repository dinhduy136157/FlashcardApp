using Flashcard.Domain.Entities;
using Flashcard.Domain.Interfaces;
using Flashcard.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Flashcard.Infrastructure.Repositories.Implementations;

public class FlashcardRepository : IFlashcardRepository
{
    private readonly FlashcardDbContext _context;
    public FlashcardRepository(FlashcardDbContext context) => _context = context;

    public async Task<IEnumerable<Domain.Entities.FlashcardItem>> GetAllAsync()
        => await _context.Flashcards.ToListAsync();

    public async Task<Domain.Entities.FlashcardItem?> GetByIdAsync(Guid id)
        => await _context.Flashcards.FindAsync(id);

    public async Task AddAsync(Domain.Entities.FlashcardItem flashcard)
    {
        await _context.Flashcards.AddAsync(flashcard);
        await _context.SaveChangesAsync();
    }
    public async Task AddRangeAsync(IEnumerable<FlashcardItem> entities)
    {
        await _context.Flashcards.AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }
    public async Task<IEnumerable<FlashcardItem>> GetByGroupIdAsync(Guid groupId)
    {
        return await _context.Flashcards
            .Where(f => f.GroupId == groupId)
            .OrderByDescending(f => f.CreatedAt)
            .ToListAsync();
    }
}