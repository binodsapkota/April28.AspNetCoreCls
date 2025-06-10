using BlogApp.Infrastructure.Data;
using BlogApp.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        // This is a generic repository implementation.
        // In a real application, you would typically inject a DbContext or similar data access layer here.
        // For simplicity, this example does not include actual data access logic.
        // You would replace the NotImplementedException with actual data access code using Entity Framework or another ORM.
        public Repository() { }
        // Example constructor for dependency injection
        // public Repository(DbContext context) { this.context = context; }


        private readonly BlogDbContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(BlogDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>() ?? throw new ArgumentNullException(nameof(_dbSet));
        }

        public async Task CreateAsync(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
           var model=await _dbSet.FindAsync(id);
            if (model == null)
            {
                throw new KeyNotFoundException($"Entity with ID {id} not found.");
            }
            _dbSet.Remove(model);
            await _context.SaveChangesAsync();
            // throw new NotImplementedException("This method should be implemented to delete an entity by its ID.");
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var result = await _dbSet.FindAsync(id);
            return result ?? throw new KeyNotFoundException($"Entity with ID {id} not found.");
            // throw new NotImplementedException("This method should be implemented to retrieve an entity by its ID.");
        }

        public async Task UpdateAsync(T entity)
        {
           _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
