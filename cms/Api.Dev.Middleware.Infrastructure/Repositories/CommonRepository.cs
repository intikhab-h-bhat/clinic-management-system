using Api.Dev.Middleware.Domain.Entities;
using Api.Dev.Middleware.Domain.Interfaces;
using Api.Dev.Middleware.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dev.Middleware.Infrastructure.Repositories
{
    
    public class CommonRepository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> dbSet;
        public CommonRepository(ApplicationDbContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }


        public  async Task<T> AddAsync(T dbRecord)
        {
            dbSet.Add(dbRecord);
            await _context.SaveChangesAsync();

            return dbRecord;
        }

        public async Task<int> DeleteAsync(T dbRecord)
        {          
            dbSet.Remove(dbRecord);
            return await _context.SaveChangesAsync();

            
        }

        public  async Task<IEnumerable<T>> GeatAllAsync()
        {
            return await  dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var record = await dbSet.FindAsync(id);
            return record;
        }

        public async Task<T> GetByNameAsync(Expression<Func<T, bool>> predicate)
        {
            var record = await dbSet.Where(predicate).FirstOrDefaultAsync();
            return record;

        }

        public async Task<int> UpdateAsync(T dbRecord)
        {
            dbSet.Update(dbRecord);

            return await _context.SaveChangesAsync();
        }
    }
}
