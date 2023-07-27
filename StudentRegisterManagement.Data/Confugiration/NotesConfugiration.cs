using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentRegisterManagement.Core.Entities;

namespace StudentRegisterManagement.Data.Confugiration
{
    public class NotesConfugiration : IEntityTypeConfiguration<Notes>
    {
        public void Configure(EntityTypeBuilder<Notes> builder)
        {
           builder.HasKey(x => x.Id);
        }
    }
}
