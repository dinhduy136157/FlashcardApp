using Flashcard.Domain.Interfaces;
using Flashcard.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Flashcard.Infrastructure.Repositories;

public class GroupRepository : IGroupRepository
{
    private readonly FlashcardDbContext _context;
    public GroupRepository(FlashcardDbContext context) => _context = context;

    public async Task<Group?> GetByIdAsync(Guid id) 
        => await _context.Groups.Include(g => g.FlashcardItems).FirstOrDefaultAsync(g => g.Id == id);

    public async Task<IEnumerable<Group>> GetByUserIdAsync(Guid userId) 
        => await _context.Groups.Where(g => g.UserId == userId).ToListAsync();

    public async Task AddAsync(Group group) => await _context.Groups.AddAsync(group);

    public async Task UpdateAsync(Group group) => _context.Groups.Update(group);

    public async Task DeleteAsync(Group group) => _context.Groups.Remove(group);

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}