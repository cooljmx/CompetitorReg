using System.Windows;
using StaffReg.Infrastructure.Concrete;

namespace StaffReg
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            var resolver = new Resolver();
        }
    }
}
