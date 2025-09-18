using Kindergarten.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kindergarten.Infrastructure.Persistence.Configurations;

public class TeacherClassroomConfiguration : IEntityTypeConfiguration<TeacherClassroom>
{
    public void Configure(EntityTypeBuilder<TeacherClassroom> builder)
    {
        builder.HasKey(tc => new { tc.TeacherId, tc.ClassroomId });

        builder.HasOne(tc => tc.Teacher)
            .WithMany(t => t.TeacherClassrooms)
            .HasForeignKey(tc => tc.TeacherId);

        builder.HasOne(tc => tc.Classroom)
            .WithMany(c => c.TeacherClassrooms)
            .HasForeignKey(tc => tc.ClassroomId);
    }
}
