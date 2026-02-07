namespace Flashcard.Domain.Interfaces;

public interface IGroupRepository
{
    Task<Group?> GetByIdAsync(Guid id);
    Task<IEnumerable<Group>> GetByUserIdAsync(Guid userId);
    Task AddAsync(Group group);
    Task UpdateAsync(Group group);
    Task DeleteAsync(Group group);
    Task SaveChangesAsync();
}