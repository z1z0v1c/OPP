using Autofac;
using OPP.DataAccess;
using OPP.UI.Data.Lookup;
using OPP.UI.Data.Repository;
using OPP.UI.View.MessageDialogService;
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

            builder.RegisterType<MessageDialogService>().As<IMessageDialogService>();

            builder.RegisterType<MainWindowViewModel>().AsSelf();
            //builder.RegisterType<MainWindowViewModel>().As<MainWindowViewModel>();
            builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>();
            builder.RegisterType<ProizvodjacViewModel>().As<IProizvodjacViewModel>();
            builder.RegisterType<ProizvodjacItemViewModel>().As<IProizvodjacItemViewModel>();
            builder.RegisterType<VrstaProizvodaItemViewModel>().As<IVrstaProizvodaItemViewModel>();


            builder.RegisterType<PregledDataService>().AsImplementedInterfaces();
            builder.RegisterType<ProizvodjacRepository>().As<IProizvodjacRepository>();
            builder.RegisterType<VrstaProizvodaRepository>().As<IVrstaProizvodaRepository>();

            return builder.Build();
        }
    }
}
