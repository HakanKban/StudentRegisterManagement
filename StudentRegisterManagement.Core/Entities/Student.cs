using StudentRegisterManagement.Core.Enums;

namespace StudentRegisterManagement.Core.Entities;
public class Student : BaseEntity<Guid>
{
    public string Name { get; set; }
    public string SurName { get; set; }
    public short Age { get; set; }
    public Gender Gender { get; set; }
    public DateOnly BirthDay { get; set; }
    public short Size { get; set; }
    public List<StudentLesson> StudentLessons { get; set; }

}
