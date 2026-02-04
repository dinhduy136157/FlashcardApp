using Microsoft.EntityFrameworkCore;
using Flashcard.Domain.Entities;

namespace Flashcard.Infrastructure.Context
{
    public class FlashcardDbContext : DbContext
    {
        public FlashcardDbContext(DbContextOptions<FlashcardDbContext> options) : base(options) { }

        public DbSet<FlashcardItem> Flashcards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FlashcardDbContext).Assembly);
        }
    }
}