using StudentRegisterManagement.Core.Entities;
using StudentRegisterManagement.Core.Interfaces;

namespace StudentRegisterManagement.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IAsyncRepository<Student> StudentRepository => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
