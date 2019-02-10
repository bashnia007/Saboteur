using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommonLibrary;
using CommonLibrary.CardsClasses;
using Saboteur.Models;
using Saboteur.MVVM;

namespace Saboteur.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public readonly MainWindow Window;
        public PlayerHandViewModel MyHand { get; set; }
        public PlayerHandViewModel EnemyHand { get; set; }
        public ObservableCollection<ObservableCollection<RouteCard>> Map { get; set; }
        public Card SelectedCard { get; set; }
        public List<Player> Players { get; set; } 
        public Player CurrentPlayer { get; set; }

        public MainViewModel()
        {
            CurrentPlayer = new Player(){Name = "Me"};
            Players = new List<Player>();
            Players.Add(CurrentPlayer);
            Players.Add(new Player(){Name = "Enemy"});

            Window = new MainWindow();
            Window.DataContext = this;
            MyHand = new PlayerHandViewModel(true, CurrentPlayer);
            EnemyHand = new PlayerHandViewModel(false, Players[1]);

            var list = new List<RouteCard>
            {
                new RouteCard(1),
                new RouteCard(2),
                new RouteCard(3),
                new RouteCard(4),
                new RouteCard(5),
                new RouteCard(6),
                new RouteCard(7),
                new RouteCard(8),
                new RouteCard(9),
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

        #region MakeActionCommand

        private RelayCommand _makeActionCommand;

        public ICommand MakeActionCommand => _makeActionCommand ??
                                             (_makeActionCommand = new RelayCommand(ExecuteMakeActionCommand,
                                                 CanExecuteMakeActionCommand));

        public void ExecuteMakeActionCommand(object obj)
        {
            var action = (ActionModel)obj;
            var command = action.Equipment;
        }

        public bool CanExecuteMakeActionCommand(object obj)
        {
            return SelectedCard != null;
        }

        #endregion

        #endregion

    }
}
