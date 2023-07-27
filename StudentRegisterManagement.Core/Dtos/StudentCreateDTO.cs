using StudentRegisterManagement.Core.Enums;

namespace StudentRegisterManagement.Core.Dtos
{
    public class StudentCreateDTO
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public short Age { get; set; }
        public Gender Gender { get; set; }
        public DateOnly BirthDay { get; set; }
        public short Size { get; set; }
        public List<LessonCreateDTO>? LessonCreateDTOs { get; set; }
    }
}
