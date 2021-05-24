using backlog.Domain.Factory;
using backlog.Domain.Ports;
using backlog.Infrastructure.Mapping;
using backlog.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace backlog.Infrastructure.BacklogStartup
{
    public class InyectionContainer
    {
        public static void Inyection(IServiceCollection services)
        {
            services.AddScoped<IRepository, RepositorySQLServer>();
            services.AddScoped<IAutoMapping, AutoMapping>();
            services.AddScoped<IFactory, factory>();
        }
    }
}
