using Autofac;
using OPP.DataAccess;
using OPP.UI.Data.Lookup;
using OPP.UI.Data.Repozitory;
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

            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>();
            builder.RegisterType<ProizvodjacViewModel>().As<IProizvodjacViewModel>();

            builder.RegisterType<PregledDataService>().AsImplementedInterfaces();
            builder.RegisterType<ProizvodjacRepozitory>().As<IProizvodjacRepozitory>();

            return builder.Build();
        }
    }
}
