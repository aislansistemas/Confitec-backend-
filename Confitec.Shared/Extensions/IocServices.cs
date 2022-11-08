using Microsoft.Extensions.DependencyInjection;
using Confitec.Infra.Contracts;
using Confitec.Infra.Repositories;
using Confitec.Infra.Uow;
using Confitec.Services.Handles.Users.Contracts;
using Confitec.Services.Handles.Users;
using Confitec.Services.QueryHandlers.Users.Contracts;
using Confitec.Services.QueryHandlers.Users;
using MediatR;
using System;
using Confitec.Shared.Config;

namespace Confitec.Shared.Extensions
{
    public static class IocServices
    {
        public static IServiceCollection AppAddIoCServices(this IServiceCollection services)
        {
            #region repositories
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();

            #endregion

            #region services 
            services.AddScoped<IUserHandler, UserHandler>();
            services.AddScoped<IUserQueryHandler, UserQueryHandler>();
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
            var assembly = AppDomain.CurrentDomain.Load("Confitec.Services");
            services.AddMediatR(assembly);
            #endregion


            return services;
        }
    }
}
