using Flashcard.Domain.Interfaces;
using Flashcard.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{
    private readonly FlashcardDbContext _context;
    public UserRepository(FlashcardDbContext context) => _context = context;

    public async Task<User?> GetByEmailAsync(string email) 
        => await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

    public async Task<User?> GetByUsernameAsync(string username) 
        => await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

    public async Task AddAsync(User user) => await _context.Users.AddAsync(user);

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}