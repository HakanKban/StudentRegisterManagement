namespace StudentRegisterManagement.Core.Entities;

public class Notes : BaseEntity<Guid>
{
    public short Score { get; set; }
    public string Explanation { get; set; }
    public Guid LessonId { get; set; }
    public Lesson Lesson { get; set; }
}
