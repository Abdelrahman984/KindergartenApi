using Kindergarten.Domain.Entities;
using Kindergarten.Infrastructure.Persistence.Seeders;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Kindergarten.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> opts) : DbContext(opts)
{
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<Teacher> Teachers { get; set; } = null!;
    public DbSet<Classroom> Classrooms { get; set; } = null!;
    public DbSet<Parent> Parents { get; set; } = null!;
    public DbSet<Attendance> Attendances { get; set; } = null!;
    public DbSet<TeacherClassroom> TeacherClassrooms { get; set; } = null!; // Junction table DbSet (m-m)
    public DbSet<Subject> Subjects { get; set; } = null!;
    public DbSet<ClassSession> ClassSessions { get; set; } = null!;
    public DbSet<Fee> Fees { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        SeedData.Seed(modelBuilder);
    }
}
