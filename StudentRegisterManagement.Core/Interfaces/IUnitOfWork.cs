using StudentRegisterManagement.Core.Entities;

namespace StudentRegisterManagement.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveAsync();
        IAsyncRepository<Student> StudentRepository { get; }
        IAsyncRepository<Notes> NoteRepository { get; }
        IAsyncRepository<Lesson> LessonRepository { get; }
    }
}
