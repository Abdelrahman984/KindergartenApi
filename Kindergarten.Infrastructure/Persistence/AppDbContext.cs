using Kindergarten.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> opts) : DbContext(opts)
{
    public DbSet<Student> Students { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Student>(b =>
        {
            b.HasKey(s => s.Id);
            b.Property(s => s.FullName).IsRequired().HasMaxLength(200);
            b.Property(s => s.ParentPhone).IsRequired().HasMaxLength(50);
            b.HasOne(s => s.Parent)
                .WithMany(p => p.Childrens)
                .HasForeignKey(s => s.ParentId)
                .OnDelete(DeleteBehavior.SetNull);
            b.HasOne(s => s.Classroom)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.ClassroomId)
                .OnDelete(DeleteBehavior.SetNull);
        });
        modelBuilder.Entity<Student>()
            .Ignore(s => s.FullName);

        modelBuilder.Entity<TeacherClassroom>()
            .HasKey(tc => new { tc.TeacherId, tc.ClassroomId });

        modelBuilder.Entity<TeacherClassroom>()
            .HasOne(tc => tc.Teacher)
            .WithMany(t => t.TeacherClassrooms)
            .HasForeignKey(tc => tc.TeacherId);

        modelBuilder.Entity<TeacherClassroom>()
            .HasOne(tc => tc.Classroom)
            .WithMany(c => c.TeacherClassrooms)
            .HasForeignKey(tc => tc.ClassroomId);

        // Seed data
        SeedData.Seed(modelBuilder);
    }
}
