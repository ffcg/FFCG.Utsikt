using System.Web.Mvc;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using StructureMap;

namespace FFCG.Utsikt.Web.Infrastructure
{
    [ModuleDependency(typeof(ServiceContainerInitialization))]
    public class MvcDependencyResolverModule : IConfigurableModule
    {
        private IContainer _container;

        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            _container = context.Container;
            DependencyResolver.SetResolver(
              new StructureMapDependencyResolver(context.Container));
        }

        public void Initialize(InitializationEngine context)
        {
            StructureMapConfiguration.Configure(_container);
        }

        public void Preload(string[] parameters)
        {
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}