using Kindergarten.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> opts) : DbContext(opts)
{
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<Teacher> Teachers { get; set; } = null!;
    public DbSet<Classroom> Classrooms { get; set; } = null!;
    public DbSet<Parent> Parents { get; set; } = null!;
    public DbSet<Attendance> Attendances { get; set; } = null!;
    public DbSet<TeacherClassroom> TeacherClassrooms { get; set; } = null!; // Junction table DbSet (m-m)

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

        // منع تكرار الحضور لنفس الطالب في نفس اليوم
        modelBuilder.Entity<Attendance>().HasIndex(a => new { a.StudentId, a.Date })
            .IsUnique();

        // Notes optional
        modelBuilder.Entity<Attendance>().Property(a => a.Notes)
            .HasMaxLength(500);

        // Date required
        modelBuilder.Entity<Attendance>().Property(a => a.Date)
            .IsRequired();


        // Seed data
        SeedData.Seed(modelBuilder);
    }
}
