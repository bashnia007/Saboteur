using Saboteur.MVVM;

namespace Saboteur.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public readonly MainWindow Window;

        public MainViewModel()
        {
            Window = new MainWindow();
            Window.DataContext = this;
        }
    }
}
