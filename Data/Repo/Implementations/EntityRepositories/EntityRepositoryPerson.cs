using Data.DataContext;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repo.Implementations.EntityRepositories;

public class EntityRepositoryPerson : EntityRepositoryBase<Person>, IPersonRepository
{
    private readonly Context _context;
    public EntityRepositoryPerson(Context context) : base(context)
    {
        _context = context;
    }

    public async Task<Person?> FindByEmail(string email)
    {
        return await _context.People.FirstOrDefaultAsync(p => p.Email == email);
    }
}
