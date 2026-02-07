using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Flashcard.Domain.Entities;
public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.ToTable("groups");
        builder.HasKey(g => g.Id);
        builder.Property(g => g.Title).IsRequired().HasMaxLength(250);
        
        builder.HasOne(g => g.User)
               .WithMany(u => u.Groups)
               .HasForeignKey(g => g.UserId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}