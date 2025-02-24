using Radio.ViewModel;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Radio
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow window = new MainWindow();
            MainWindowVM VM = new MainWindowVM();
            window.DataContext = VM;
            window.Show();
        }
    }

}
