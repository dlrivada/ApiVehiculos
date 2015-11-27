using System.Data.Entity;
using System.Web.Http;
using BaseRepositorio.ViewModel;
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
            container.RegisterType<IViewModel<Type>, TipoVehiculoViewModel>();
            container.RegisterType<IViewModel<Vehicle>, VehiculoViewModel>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

        }
    }
}
