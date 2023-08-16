using System.Linq.Expressions;
using Data.DataContext;
using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repo.Implementations.EntityRepositories
{
    public class EntityRepositoryBase<T> : IRepositoryBase<T> where T : Entity
    {
        private readonly Context _context;
        private readonly DbSet<T> _entities;

        public EntityRepositoryBase(Context context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
            var result = _entities.Add(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IList<T>> FindAll(PaginationRequest pr, Expression<Func<T, bool>>? filter = null)
        {
            var query = _entities.AsQueryable();
            if(filter != null)
            {
                query = query.Where(filter);
            }
            return await query.Take(pr.Take).Skip(pr.GetPage()).ToListAsync();
        }

        public async Task<T?> FindById(string id)
        {
            return await _entities.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Remove(T entity)
        {
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> Update(T entity)
        {
            var result = _entities.Update(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
