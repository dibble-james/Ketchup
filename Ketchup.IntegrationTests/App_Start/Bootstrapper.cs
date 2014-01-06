namespace Ketchup.IntegrationTests
{
    using System.Data.Entity;

    using JamesDibble.ApplicationFramework.Data.Persistence;
    using JamesDibble.ApplicationFramework.Data.Persistence.EntityFrameworkCodeFirst;

    using Ketchup.Api;
    using Ketchup.Persistence.EntityFramework;
    using System.Web.Mvc;
    using Microsoft.Practices.Unity;
    using Unity.Mvc4;

    public static class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            RegisterTypes(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            var context = KetchupInitialiser.Initialise<KetchupInitialiser>();

            container.RegisterInstance<DbContext>(context);
            container.RegisterInstance(context);

            container.RegisterType<IPersistenceManager, EntityFrameworkPersistenceManager>();
            container.RegisterType<IProductManager, ProductManager>();
        }
    }
}