using Guilherme.LojaVirtualApi.Models.Entities;
using Guilherme.LojaVirtualApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Guilherme.LojaVirtualApi.Repository.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected EFContext _context;
        protected DbSet<T> _dbSet;

        public Repository(EFContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<IEnumerable<T>> FindAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> FindById(long id)
        {
            return await _dbSet.FirstOrDefaultAsync(t => t.Id.Equals(id));
        }

        public async Task<T> Add(T t)
        {
            await _dbSet.AddAsync(t);

            await _context.SaveChangesAsync();

            return t;
        }

        public async Task<T> Update(T t)
        {
            var result = await _dbSet.FindAsync(t.Id);

            if(result == null)
            {
                return null;
            }

            _context.Entry(result).CurrentValues.SetValues(t);

            await _context.SaveChangesAsync();

            return t;
        }

        public async Task Delete(long id)
        {
            T t = await FindById(id);

            if(t != null)
            {
                _dbSet.Remove(t);

                await _context.SaveChangesAsync();
            }
        }
    }
}
