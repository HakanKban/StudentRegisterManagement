﻿using Microsoft.EntityFrameworkCore;
using StudentRegisterManagement.Core.Interfaces;

namespace StudentRegisterManagement.Data.Repository
{
    public class AsyncRepository<T> : IAsyncRepository<T> where T : class
    {
        private readonly MyContext _context;

        public AsyncRepository(MyContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await Task.CompletedTask;
        }

        public Task<List<T>> GetAllAsync()
        {
            return _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid entityId)
        {
            return await _context.FindAsync<T>(new object[] {entityId} );
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
