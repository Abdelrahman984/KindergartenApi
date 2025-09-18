using Kindergarten.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kindergarten.Infrastructure.Persistence.Configurations;

public class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
{
    public void Configure(EntityTypeBuilder<Attendance> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasIndex(a => new { a.StudentId, a.Date })
            .IsUnique();

        builder.Property(a => a.Notes)
            .HasMaxLength(500);

        builder.Property(a => a.Date)
            .IsRequired();
    }
}
