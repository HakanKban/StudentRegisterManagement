using Microsoft.Extensions.DependencyInjection;
using StudentRegisterManagement.Core.Entities;
using StudentRegisterManagement.Core.Interfaces;

namespace StudentRegisterManagement.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyContext _context;
        private readonly IServiceProvider _serviceProvider;

        public UnitOfWork(MyContext context,IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _context = context;
        }

        public IAsyncRepository<Student> _studentRepository;

        public IAsyncRepository<Notes> _noteRepository;

        public IAsyncRepository<Lesson> _lessonRepository;

        public IAsyncRepository<Student> StudentRepository
        {
            get
            {
                if (_studentRepository == default(IAsyncRepository<Student>))
                    _studentRepository = _serviceProvider.GetRequiredService<IAsyncRepository<Student>>();

                return _studentRepository;
            }

        }   
        public IAsyncRepository<Notes> NoteRepository
        {
            get
            {
                if (_noteRepository == default(IAsyncRepository<Notes>))
                    _noteRepository = _serviceProvider.GetRequiredService<IAsyncRepository<Notes>>();

                return _noteRepository;
            }

        }  
        public IAsyncRepository<Lesson> LessonRepository
        {
            get
            {
                if (_lessonRepository == default(IAsyncRepository<Lesson>))
                    _lessonRepository = _serviceProvider.GetRequiredService<IAsyncRepository<Lesson>>();

                return _lessonRepository;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
