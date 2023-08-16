using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IPersonRepository : IRepositoryBase<Person>
    {
        Task<Person?> FindByEmail(string email);
    }
}
