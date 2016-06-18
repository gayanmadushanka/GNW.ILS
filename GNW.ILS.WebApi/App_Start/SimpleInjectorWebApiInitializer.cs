using System.Web.Http;
using GNW.ILS.Service.EF.Contexts;
using GNW.ILS.Service.EF.Repositories;
using GNW.ILS.Service.EF.UnitsOfWork;
using GNW.ILS.Service.Persistence.Repositories;
using GNW.ILS.Service.Persistence.UnitsOfWork;
using GNW.ILS.WebApi;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(SimpleInjectorWebApiInitializer), "Initialize")]

namespace GNW.ILS.WebApi
{
    public static class SimpleInjectorWebApiInitializer
    {
        public static void Initialize()
        {
            // Create IoC container
            var container = new Container();

            // Register dependencies
            InitializeContainer(container);
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Options.EnableDynamicAssemblyCompilation = false;
            // Verify registrations
            container.Verify();

            // Set Web API dependency resolver
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void InitializeContainer(Container container)
        {
            // TODO: Register context, unit of work and repos with per request lifetime
            container.RegisterWebApiRequest<IGNWILSDbContext, GNWILSDbContext>();
            container.RegisterWebApiRequest<IGNWILSUnitOfWork, GNWILSUnitOfWork>();
            container.RegisterWebApiRequest<IAddressTypeRepository, AddressTypeRepository>();
        }
    }
}