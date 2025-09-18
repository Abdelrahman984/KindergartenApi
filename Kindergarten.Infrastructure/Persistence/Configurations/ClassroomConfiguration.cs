using Kindergarten.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kindergarten.Infrastructure.Persistence.Configurations;

public class ClassroomConfiguration : IEntityTypeConfiguration<Classroom>
{
    public void Configure(EntityTypeBuilder<Classroom> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.Capacity)
            .IsRequired();

        builder.HasMany(c => c.Students)
            .WithOne(s => s.Classroom)
            .HasForeignKey(s => s.ClassroomId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(c => c.ClassSessions)
            .WithOne(cs => cs.Classroom)
            .HasForeignKey(cs => cs.ClassroomId);

        builder.HasMany(c => c.TeacherClassrooms)
            .WithOne(tc => tc.Classroom)
            .HasForeignKey(tc => tc.ClassroomId);
    }
}
