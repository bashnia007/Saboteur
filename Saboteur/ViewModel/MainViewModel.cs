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
		//public Card SelectedCard { get; set; }
		public string TextInTextBox { get; set; }

        public MainViewModel()
        {
            Window = new MainWindow();
            Window.DataContext = this;
            MyHand = new PlayerHandViewModel(true);
            EnemyHand = new PlayerHandViewModel(false);

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

		#region
		private RelayCommand _sendCommand;

		public ICommand SendCommand => _sendCommand ?? (_sendCommand =
												  new RelayCommand(ExecuteSendCommand,
													  CanExecuteSendCommand));

		private void ExecuteSendCommand(object obj)
		{

		}

		private bool CanExecuteSendCommand(object obj)
		{
			return (!string.IsNullOrEmpty(TextInTextBox));
		}
		#endregion

		#endregion

	}
}
