namespace StudentRegisterManagement.Core.Dtos
{
    public class NotesUpdateDTO
    {
        public Guid Id { get; set; }
        public short Score { get; set; }
        public string Explanation { get; set; }
    }
}
