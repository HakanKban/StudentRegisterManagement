namespace StudentRegisterManagement.Core.Entities;

public class Lesson : BaseEntity<Guid>
{
    public string LessonName { get; set; }
    public string Explanation { get; set; }
    public List<StudentLesson> StudentLesson { get; set; }
    public List<Notes> Notes { get; set; }

}
