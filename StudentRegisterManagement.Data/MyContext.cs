using Microsoft.EntityFrameworkCore;
using StudentRegisterManagement.Core.Entities;

namespace StudentRegisterManagement.Data;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Student> Students { get; set; }
}
