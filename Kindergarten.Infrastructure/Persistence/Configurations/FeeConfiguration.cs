using Kindergarten.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kindergarten.Infrastructure.Persistence.Configurations;

public class FeeConfiguration : IEntityTypeConfiguration<Fee>
{
    public void Configure(EntityTypeBuilder<Fee> builder)
    {
        builder.ToTable("Fees");

        builder.HasKey(f => f.Id);

        builder.Property(f => f.Amount)
            .HasColumnType("decimal(10,2)")
            .IsRequired();

        builder.Property(f => f.DueDate)
            .IsRequired();

        builder.Property(f => f.PaymentDate)
            .IsRequired(false);

        builder.Property(f => f.Status)
            .HasConversion<string>() // تخزين الحالة كـ نص بدل int
            .IsRequired();

        // Relationships
        builder.HasOne(f => f.Student)
            .WithMany(s => s.Fees)
            .HasForeignKey(f => f.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(f => f.Parent)
            .WithMany(p => p.Fees)
            .HasForeignKey(f => f.ParentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
