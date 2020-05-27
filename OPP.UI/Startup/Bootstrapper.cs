using Autofac;
using OPP.DataAccess;
using OPP.UI.Data;
using OPP.UI.ViewModel;

namespace OPP.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<OPPDbContext>().AsSelf();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<ProizvodjacDataService>().As<IProizvodjacDataService>();

            return builder.Build();
        }
    }
}
