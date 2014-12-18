using Apworks.Application;
using Apworks.Config.Fluent;
using Apworks.Repositories;
using Apworks.Repositories.EntityFramework;
using CloudNotes.Domain.Repositories.EntityFramework;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace CloudNotes.WebAPI
{
    public static class ApworksConfig
    {
        public static void Initialize()
        {
            AppRuntime
                .Instance
                .ConfigureApworks()
                .UsingUnityContainerWithDefaultSettings()
                .Create((sender, e) =>
                {
                    var unityContainer = e.ObjectContainer.GetWrappedContainer<UnityContainer>();
                    unityContainer.RegisterInstance(new CloudNotesContext(), new PerResolveLifetimeManager())
                        .RegisterType<IRepositoryContext, EntityFrameworkRepositoryContext>(new HierarchicalLifetimeManager(),
                            new InjectionConstructor(new ResolvedParameter<CloudNotesContext>()))
                        .RegisterType(typeof(IRepository<>), typeof(EntityFrameworkRepository<>));

                    GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(unityContainer);
                })
                .Start();
        }
    }
}