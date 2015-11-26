using System;
using System.Data.Entity;
using System.Web.Http;
using BaseRepositorio.Repositorio;
using Microsoft.Practices.Unity;
using RepositorioVehiculos;
using Unity.WebApi;

namespace ApiVehiculos
{
    public static class Bootstraper
    {
        public static void Init(UnityContainer container)
        {
            container.RegisterType<DbContext, Vehiculos05Entities>();
            container.RegisterType<GenericRepository<Type>>();
            container.RegisterType<GenericRepository<Vehicle>>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

        }
    }
}
