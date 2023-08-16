using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.DataContext;

public class Context : DbContext
{

    public Context(DbContextOptions<Context> options) : base(options) { }

    public DbSet<Person> People { get; set; }

}
