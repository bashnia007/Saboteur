using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommonLibrary.CardsClasses;
using Saboteur.MVVM;

namespace Saboteur.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public readonly MainWindow Window;
        public PlayerHandViewModel MyHand { get; set; }
        public PlayerHandViewModel EnemyHand { get; set; }
        public ObservableCollection<ObservableCollection<RouteCard>> Map { get; set; }

        public string Text { get; set; }

        public MainViewModel()
        {
            Window = new MainWindow();
            Text = "dddd";
            Window.DataContext = this;
            MyHand = new PlayerHandViewModel();
            EnemyHand = new PlayerHandViewModel();

            var list = new List<RouteCard>
            {
                new RouteCard(),
                new RouteCard(),
                new RouteCard(),
                new RouteCard(),
                new RouteCard(),
                new RouteCard(),
                new RouteCard(),
                new RouteCard(),
                new RouteCard(),
            };
            Map = new ObservableCollection<ObservableCollection<RouteCard>>();
            Map.Add(new ObservableCollection<RouteCard>(list));
            Map.Add(new ObservableCollection<RouteCard>(list));
            Map.Add(new ObservableCollection<RouteCard>(list));
            Map.Add(new ObservableCollection<RouteCard>(list));
            Map.Add(new ObservableCollection<RouteCard>(list));
            Map.Add(new ObservableCollection<RouteCard>(list));
            Map.Add(new ObservableCollection<RouteCard>(list));
        }

        #region Commands

        #region BuildTunnelCommand

        private RelayCommand _buildTunnelCommand;

        public ICommand BuildTunnelCommand => _buildTunnelCommand ?? (_buildTunnelCommand =
                                                  new RelayCommand(ExecuteBuildTunnelCommand,
                                                      CanExecuteBuildTunnelCommand));

        private void ExecuteBuildTunnelCommand(object obj)
        {

        }

        private bool CanExecuteBuildTunnelCommand(object obj)
        {
            return true;
        }

        #endregion

        #endregion

    }
}
