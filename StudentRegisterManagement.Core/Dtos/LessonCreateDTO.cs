namespace StudentRegisterManagement.Core.Dtos
{
    public class LessonCreateDTO
    {
        public string LessonName { get; set; }
        public string Explanation { get; set; }
        public Guid? StudentId { get; set; }
        public List<NotesCreateDTO>? NotesCreateDTOs { get; set; }
    }
}
