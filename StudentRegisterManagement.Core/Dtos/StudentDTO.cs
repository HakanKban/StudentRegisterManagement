using StudentRegisterManagement.Core.Enums;

namespace StudentRegisterManagement.Core.Dtos
{
    public class StudentDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public short Age { get; set; }
        public Gender Gender { get; set; }
        public DateOnly BirthDay { get; set; }
        public short Size { get; set; }
    }
}
