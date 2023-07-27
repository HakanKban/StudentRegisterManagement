using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentRegisterManagement.Core.Entities;

namespace StudentRegisterManagement.Data.Confugiration;

public class LessonConfugiration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.StudentLesson)
               .WithOne(x => x.Lesson)
               .HasForeignKey(x => x.LessonId);

        builder.HasMany(x => x.Notes)
              .WithOne(x => x.Lesson)
              .HasForeignKey(x => x.LessonId);
    }
}
