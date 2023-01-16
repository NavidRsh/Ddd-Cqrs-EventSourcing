using FluentValidation;
using Mapster;
using MapsterMapper;
using DddCqrs.Crud.Application.Common.Behaviours;
using DddCqrs.Crud.Application.CustomValidations;
using DddCqrs.Crud.Application.Services.EventHandlers;
using DddCqrs.Crud.Application.Services.PubSub;
using DddCqrs.Crud.Domain.Events;
using DddCqrs.Crud.Domain.ValueObjects;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DddCqrs.Crud.Application
{
    public static class StartupModule
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehaviour<,>));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            var config = new TypeAdapterConfig();

            services.AddSingleton(config);

            services.AddScoped<IMapper, ServiceMapper>();

            services.AddTransient<IDomainEventHandler<CustomerId, CustomerCreatedEvent>, CustomerEventHandler>();

            services.AddTransient<IDomainEventHandler<CustomerId, CustomerUpdatedEvent>, CustomerEventHandler>();

            services.AddTransient<IDomainEventHandler<CustomerId, CustomerDeletedEvent>, CustomerEventHandler>();

            services.AddScoped<ITransientDomainEventSubscriber, TransientDomainEventPubSub>();

            services.AddScoped<ITransientDomainEventPublisher, TransientDomainEventPubSub>();

            services.AddScoped<ICustomerValidations, CustomerValidations>(); 

            return services; 
        }
    }
}
