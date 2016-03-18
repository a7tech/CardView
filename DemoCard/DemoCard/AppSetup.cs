using Autofac;
using DemoCard.Services;
using DemoCard.ViewModels;

namespace DemoCard
{
    public class AppSetup
    {
        /// <summary>
        /// Creates an instance of the AutoFac container
        /// </summary>
        /// <returns>A new instance of the AutoFac container</returns>
        /// <remarks>
        /// https://github.com/autofac/Autofac/wiki
        /// </remarks>
        public IContainer CreateContainer()
        {
            ContainerBuilder cb = new ContainerBuilder();

            RegisterDepenencies(cb);

            return cb.Build();
        }

        protected virtual void RegisterDepenencies(ContainerBuilder cb)
        {
            // Services
            cb.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();

            // View Models
            cb.RegisterType<CardViewModel>().SingleInstance();

        }
    }
}