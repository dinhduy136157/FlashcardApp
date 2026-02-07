using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Flashcard.Domain.Entities;

namespace Flashcard.Infrastructure.Persistence.Configurations
{
    public class FlashcardConfiguration : IEntityTypeConfiguration<Flashcard.Domain.Entities.FlashcardItem>
    {
        public void Configure(EntityTypeBuilder<FlashcardItem> builder)
       {
              builder.ToTable("flashcards");
              builder.HasKey(f => f.Id);

              builder.Property(f => f.Word).IsRequired().HasMaxLength(250);
              builder.Property(f => f.Meaning).IsRequired();
              builder.Property(f => f.Example).HasMaxLength(1000);
              
              builder.Property(f => f.CreatedAt)
                     .HasDefaultValueSql("CURRENT_TIMESTAMP");

              builder.HasOne(f => f.Group)
                     .WithMany(g => g.FlashcardItems)
                     .HasForeignKey(f => f.GroupId)
                     .OnDelete(DeleteBehavior.Cascade);
       }
    }
}