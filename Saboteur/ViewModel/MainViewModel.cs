using CommonLibrary;
using CommonLibrary.CardsClasses;
using CommonLibrary.Enumerations;
using CommonLibrary.Message;
using Saboteur.Models;
using Saboteur.MVVM;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
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
        public Visibility ReadyButtonVisibility { get; set; }
		public string TextInChatBox { get; set; }
        public string Login { get; set; }

		private readonly Client _client;

        public MainViewModel(string login)
        {
            CurrentPlayer = new Player
            {
                Name = Login
            };
            Players = new List<Player>();
            Players.Add(CurrentPlayer);
            Players.Add(new Player());

            Window = new MainWindow();
            Window.DataContext = this;
            MyHand = new PlayerHandViewModel(true, CurrentPlayer);
            EnemyHand = new PlayerHandViewModel(false, Players[1]);

            Login = login;

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
            _client.SendMessage(new InitializeMessage
            {
                Login = login,
            });
			_client.OnReceiveMessageEvent += ReceivedMessageFromClient;

            ReadyButtonVisibility = Visibility.Visible;
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

		#region SendCommand 
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
			OnPropertyChanged(nameof(TextInTextBox));
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

        #region ReadyCommand

        private RelayCommand _readyCommand;

        public ICommand ReadyCommand => _readyCommand ?? (_readyCommand =
                                           new RelayCommand(ExecuteReadyCommand,
                                               CanExecuteReadyCommand));

        private void ExecuteReadyCommand(object obj)
        {
            _client.SendMessage(new GameMessage
            {
                SenderId = CurrentPlayer.Id,
                MessageType = GameMessageType.ReadyToPlay
            });
            ReadyButtonVisibility = Visibility.Hidden;
            OnPropertyChanged(nameof(ReadyButtonVisibility));
        }

        private bool CanExecuteReadyCommand(object arg)
        {
            return true;
        }

        #endregion

        #endregion

        #region Private methods

        private void ReceivedMessageFromClient(Message message)
        {
            switch (message.MessageType)
            {
                case GameMessageType.InitializeMessage:
                    HandleInitMessage((InitializeMessage) message);
                    break;
                case GameMessageType.TextMessage:
                    HandleTextMessage((TextMessage)message);
                    break;
            }
        }

        private void HandleInitMessage(InitializeMessage message)
        {
            CurrentPlayer.Id = message.Id;
        }

        private void HandleTextMessage(TextMessage message)
        {
            TextInChatBox += ((TextMessage)message).Text;
            OnPropertyChanged(nameof(TextInChatBox));
        }

        #endregion

    }
}
