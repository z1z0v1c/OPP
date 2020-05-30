using Autofac;
using OPP.DataAccess;
using OPP.UI.Data;
using OPP.UI.ViewModel;
using Prism.Events;

namespace OPP.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<OPPDbContext>().AsSelf();

            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>();
            builder.RegisterType<ProizvodjacViewModel>().As<IProizvodjacViewModel>();

            builder.RegisterType<PregledDataService>().AsImplementedInterfaces();
            builder.RegisterType<ProizvodjacDataService>().As<IProizvodjacDataService>();

            return builder.Build();
        }
    }
}
