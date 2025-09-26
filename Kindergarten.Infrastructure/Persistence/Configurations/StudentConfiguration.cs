using Kindergarten.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kindergarten.Infrastructure.Persistence.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.FullName)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasOne(s => s.Parent)
            .WithMany(p => p.Childrens)
            .HasForeignKey(s => s.ParentId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(s => s.Classroom)
            .WithMany(c => c.Students)
            .HasForeignKey(s => s.ClassroomId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Property(s => s.Age)
            .HasComputedColumnSql(
                "DATEDIFF(YEAR, DateOfBirth, GETDATE()) - " +
                "CASE WHEN (MONTH(DateOfBirth) > MONTH(GETDATE())) " +
                "OR (MONTH(DateOfBirth) = MONTH(GETDATE()) AND DAY(DateOfBirth) > DAY(GETDATE())) " +
                "THEN 1 ELSE 0 END",
                stored: false);
    }
}
