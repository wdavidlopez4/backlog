using AutoMapper.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration; //getConnectionString
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using backlog.Infrastructure.BacklogContext;
using Microsoft.EntityFrameworkCore;
using MediatR;
using backlog.Application.EpicService.CommandEpicAssignToSpring;
using backlog.Application.SpringServices.CommandSpringCreate;
using System.Reflection;
using backlog.Application.SpringServices.QuerySpringByMonth;

namespace backlog.Infrastructure.BacklogStartup
{
    public static class StartupBacklog
    {
        public static void ConfigurationServices(IServiceCollection services, IConfiguration configuration)
        {
            InyectionContainer.Inyection(services);
            ConfigurationSqlServer(services, configuration);
            ConfigurarMapper(services);
            ConfigurarMediador(services);


        }

        /// <summary>
        /// configura el sql server
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        private static void ConfigurationSqlServer(IServiceCollection services, IConfiguration configuration)
        {
            // entity framework db context
            string connString = configuration.GetConnectionString("CafeConnectionString"); //obtenemos la cadena de coneccion DESDE EL ARCHIVO APPSETTINGS
            services.AddDbContext<BacklogContextSqlServer>(
                options => options.UseSqlServer(connString));
        }

        /// <summary>
        /// configura el mapeo del sistema dto-entitdades de modelo
        /// </summary>
        /// <param name="services"></param>
        private static void ConfigurarMapper(IServiceCollection services)
        {
            //mapeo de entidades
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        /// <summary>
        /// configura el patron mediator controladores- servicios
        /// </summary>
        /// <param name="services"></param>
        private static void ConfigurarMediador(IServiceCollection services)
        {
            services.AddMediatR(typeof(EpicAssignToSpring).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(SpringCreate).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(SpringByMonth).GetTypeInfo().Assembly);
        }
    }
}
