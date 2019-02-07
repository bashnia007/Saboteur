using Saboteur.MVVM;

namespace Saboteur.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public readonly MainWindow Window;
        public PlayerHandViewModel MyHand { get; set; }
        public PlayerHandViewModel EnemyHand { get; set; }

        public MainViewModel()
        {
            Window = new MainWindow();
            Window.DataContext = this;
            MyHand = new PlayerHandViewModel();
            EnemyHand = new PlayerHandViewModel();
        }
    }
}
