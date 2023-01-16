using DddCqrs.Crud.Application.Gateways.EventStoreRepositories;
using DddCqrs.Crud.Persistence.EventStore.Ef.Data;
using DddCqrs.Crud.Persistence.EventStore.Ef.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DddCqrs.Crud.Persistence.EventStore.Ef
{
    public static class StartupModule
    {
        public static IServiceCollection RegisterEventStoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CrudTestEventStoreContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("EventStoreConnection"), b =>
                {
                    b.MigrationsAssembly(typeof(StartupModule).Assembly.GetName().Name);
                });
            });

            services.AddScoped<ICustomerEventStoreRepository, CustomerEventStoreRepository>();

            return services; 
        }
    }
}
