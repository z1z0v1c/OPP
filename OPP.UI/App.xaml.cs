using Autofac;
using OPP.UI.Data;
using OPP.UI.Startup;
using OPP.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace OPP.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var bootstraper = new Bootstrapper();
            var container = bootstraper.Bootstrap();
            container.Resolve<MainWindow>().Show();
            //new MainWindow(new MainViewModel(new ProizvodjacDataService())).Show();
        }

        private void Application_DispatcherUnhandledException(object sender, 
            System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Дошло је до грешке. Покушајте поново.");
            e.Handled = true;
        }
    }
}
