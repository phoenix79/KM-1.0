using System.Windows;
using GalaSoft.MvvmLight.Threading;

namespace Kerbal_Memorial_1._0
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            DispatcherHelper.Initialize();

        }
    }
}
