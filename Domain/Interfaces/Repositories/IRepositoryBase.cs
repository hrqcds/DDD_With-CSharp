using System.Linq.Expressions;
using Domain.Dtos;
using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IRepositoryBase<T> where T : Entity
{
    Task<IList<T>> FindAll(PaginationRequest pr, Expression<Func<T, bool>>? filter = null);
    Task<T?> FindById(string id);
    Task<T> Add(T entity);
    Task<T> Update(T entity);
    Task Remove(T entity);
    
}
