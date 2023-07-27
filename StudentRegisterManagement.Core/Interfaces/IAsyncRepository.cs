using System.Linq.Expressions;

namespace StudentRegisterManagement.Core.Interfaces;
public interface IAsyncRepository<T> where T : class
{
    Task<bool> AnyAsync(Expression<Func<T,bool>> expression);
    Task<T> GetByIdAsync(Guid entityId);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<List<T>> GetAllAsync();
}
