namespace StudentRegisterManagement.Core.Entities
{
    public class StudentLesson //Many to Many ilişki için tutulan cross table
    {
        public Guid StudentId { get; set; }
        public Guid LessonId { get; set; }
        public Student Student  { get; set; }
        public Lesson Lesson { get; set; }
    }
}
