using Kindergarten.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kindergarten.Infrastructure.Persistence.Configurations;

public class ClassSessionConfiguration : IEntityTypeConfiguration<ClassSession>
{
    public void Configure(EntityTypeBuilder<ClassSession> builder)
    {
        builder.HasKey(cs => cs.Id);

        builder.Property(cs => cs.StartTime)
            .IsRequired();

        builder.Property(cs => cs.EndTime)
            .IsRequired();

        builder.HasOne(cs => cs.Classroom)
            .WithMany(c => c.ClassSessions)
            .HasForeignKey(cs => cs.ClassroomId);

        builder.HasOne(cs => cs.Teacher)
            .WithMany(t => t.ClassSessions)
            .HasForeignKey(cs => cs.TeacherId);

        builder.HasOne(cs => cs.Subject)
            .WithMany(s => s.ClassSessions)
            .HasForeignKey(cs => cs.SubjectId);
    }
}
