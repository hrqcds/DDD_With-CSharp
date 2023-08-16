using Data.DataContext;
using Data.Repo.Implementations.EntityRepositories;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data
{
    public static class DataExtensions
    {
        public static IServiceCollection AddEntityFramework(this IServiceCollection services)
        {
            services.AddDbContext<Context>(options =>
            {
                options.UseInMemoryDatabase("database");
            });

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryBase<>), typeof(EntityRepositoryBase<>));
            services.AddScoped<IPersonRepository, EntityRepositoryPerson>();

            return services;
        }

    }
}
