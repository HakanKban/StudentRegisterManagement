using Microsoft.EntityFrameworkCore;
using StudentRegisterManagement.Core.Entities;

namespace StudentRegisterManagement.Data;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Student> Student { get; set; }
    public DbSet<Notes> Note { get; set; }
    public DbSet<Lesson> Lesson { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentLesson>().HasKey(x => new { x.StudentId, x.LessonId });
    }
    //public DbSet<StudentLesson> StudentLesson { get; set; }
}
