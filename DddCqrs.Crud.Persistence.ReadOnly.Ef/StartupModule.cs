using DddCqrs.Crud.Application.Gateways.ReadModelRepositories.Customer;
using DddCqrs.Crud.Persistence.ReadDomain.Ef.Data;
using DddCqrs.Crud.Persistence.ReadDomain.Ef.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DddCqrs.Crud.Persistence.ReadDomain.Ef
{
    public static class StartupModule 
    {
        public static IServiceCollection RegisterReadDomainServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CrudTestReadDomainContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ReadModelConnection"), b =>
                {
                    b.MigrationsAssembly(typeof(StartupModule).Assembly.GetName().Name);
                });
            });

            services.AddScoped<ICustomerReadOnlyRepository, CustomerReadOnlyRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>(); 

            return services; 
        }
    }
}
