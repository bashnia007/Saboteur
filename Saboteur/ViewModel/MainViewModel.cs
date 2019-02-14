using CommonLibrary;
using CommonLibrary.CardsClasses;
using CommonLibrary.Enumerations;
using CommonLibrary.Message;
using Saboteur.Models;
using Saboteur.MVVM;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

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
		public string TextInTextBox { get; set; }

		private Client _client;

        public MainViewModel()
        {
            CurrentPlayer = new Player(){Name = "Me", Id = 1};
            Players = new List<Player>();
            Players.Add(CurrentPlayer);
            Players.Add(new Player(){Name = "Enemy", Id = 2});

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

            _client = new Client();
            _client.EstablishConnection();
        }

        #region Commands

        #region BuildTunnelCommand - команда, вызываемая про постройке карты тунеля

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
			_client.SendMessage(new TextMessage()
			{
				SenderId = CurrentPlayer.Id,
				Text = TextInTextBox
			});
			TextInTextBox = "";
		}

		private bool CanExecuteSendCommand(object obj)
		{
			return (!string.IsNullOrEmpty(TextInTextBox));
		}
		#endregion

        #region MakeActionCommand - команда, вызываемая при выборе игрока сыграть карту действия

        private RelayCommand _makeActionCommand;

        public ICommand MakeActionCommand => _makeActionCommand ??
                                             (_makeActionCommand = new RelayCommand(ExecuteMakeActionCommand,
                                                 CanExecuteMakeActionCommand));

        public void ExecuteMakeActionCommand(object obj)
        {
            // получаем и сохраняем выбранное действие
            var action = (ActionModel)obj;
            // отправка сообщения, хранящего выбранное действие, ID отправителя и ID игрока, на которого действие направлено
            _client.SendMessage(new ActionMessage
            {
                ActionType = ActionType.BreakLamp,
                SenderId = CurrentPlayer.Id,
                RecepientId = CurrentPlayer.Id
            });
        }

        public bool CanExecuteMakeActionCommand(object obj)
        {
            return SelectedCard != null;
        }

        #endregion

        #endregion

	}
}
