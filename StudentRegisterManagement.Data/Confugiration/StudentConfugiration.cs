using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentRegisterManagement.Core.Entities;

namespace StudentRegisterManagement.Data.Confugiration;
public class StudentConfugiration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.StudentLessons)
               .WithOne(x => x.Student)
               .HasForeignKey(x => x.StudentId);
    }
}
