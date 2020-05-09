using Datos.Repository;
using Datos.Repository.UnidadDeTrabajo;
using DatosLayer.Repository.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackMostaza.Middleware
{
    public static class IoC
    {
        public static IServiceCollection AgregarDependencia( this IServiceCollection services)
        {
            services.AddScoped(typeof(IUnidadDeTrabajo<>), typeof(UnidadDeTrabajo<>));
            services.AddScoped(typeof(IRepositorioGenerico<>), typeof(RepositorioGenerico<>));
            services.AddScoped<IUsuariorepositorio, Usuariorepositorio>();
            services.AddScoped<IPerfilRepositorio, PerfilRepositorio>();


            return services;
        }
    }
}
