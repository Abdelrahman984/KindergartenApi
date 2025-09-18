using Kindergarten.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kindergarten.Infrastructure.Persistence.Configurations;

public class ParentConfiguration : IEntityTypeConfiguration<Parent>
{
    public void Configure(EntityTypeBuilder<Parent> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.FullName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(p => p.PhoneNumber)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.Address)
            .IsRequired()
            .HasMaxLength(300);

        builder.HasMany(p => p.Childrens)
            .WithOne(s => s.Parent)
            .HasForeignKey(s => s.ParentId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
