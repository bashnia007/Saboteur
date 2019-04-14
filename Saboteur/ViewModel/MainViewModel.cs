using CommonLibrary;
using CommonLibrary.CardsClasses;
using CommonLibrary.Enumerations;
using CommonLibrary.Message;
using Saboteur.Models;
using Saboteur.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;
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
        public string RoleImage { get; set; }
        public string LampImage { get; set; }
        public string PickImage { get; set; }
        public string TrolleyImage { get; set; }
        
        private readonly Client _client;
        private bool _isMyTurn;

        public MainViewModel(string login)
        {
            Login = login;
            CurrentPlayer = new Player
            {
                Name = Login
            };
            Players = new List<Player>();
            Players.Add(CurrentPlayer);

            Window = new MainWindow();
            Window.DataContext = this;
            MyHand = new PlayerHandViewModel(true, CurrentPlayer);
            
            PrepareMap();

            _client = new Client();
            _client.EstablishConnection();
            _client.SendMessage(new InitializeMessage
            {
                Login = login,
            });
			_client.OnReceiveMessageEvent += ReceivedMessageFromServer;

            ReadyButtonVisibility = Visibility.Visible;

            LampImage = ImagePaths.LampFix;
            PickImage = ImagePaths.LampFix;
            TrolleyImage = ImagePaths.LampFix;
        }

		#region Commands

		#region BuildTunnelCommand - команда, вызываемая про постройке карты тунеля

		private RelayCommand _buildTunnelCommand;

        public ICommand BuildTunnelCommand => _buildTunnelCommand ?? (_buildTunnelCommand =
                                                  new RelayCommand(ExecuteBuildTunnelCommand,
                                                      CanExecuteBuildTunnelCommand));

        private void ExecuteBuildTunnelCommand(object obj)
        {
            var mapItem = (RouteCard) obj;
            _client.SendMessage(new BuildMessage
            {
                Coordinates = mapItem.Coordinates,
                SenderId = CurrentPlayer.Id,
                CardId = SelectedCard.Id,
                RouteCard = SelectedCard as RouteCard
            });
        }

        private bool CanExecuteBuildTunnelCommand(object obj)
        {
            return _isMyTurn && obj is RouteCard && SelectedCard is RouteCard;
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
				Login = Login,
				Text = Login + ": " + TextInTextBox + Environment.NewLine
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
                ActionType = ((ActionCard)SelectedCard).Action,
                SenderId = CurrentPlayer.Id,
                RecepientId = action.Player.Id
            });
        }

        public bool CanExecuteMakeActionCommand(object obj)
        {
            return SelectedCard != null && SelectedCard is ActionCard;
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

        private void ReceivedMessageFromServer(Message message)
        {
            switch (message.MessageType)
            {
                case GameMessageType.InitializeMessage:
                    HandleInitMessage((InitializeMessage) message);
                    break;
                case GameMessageType.TextMessage:
                    HandleTextMessage((TextMessage)message);
                    break;
                case GameMessageType.UpdateTableMessage:
                    HandleUpdateTableMessage((UpdateTableMessage)message);
                    break;
                case GameMessageType.BuildMessage:
                    HandleBuildMessage((BuildMessage) message);
                    break;
                case GameMessageType.SetTurnMessage:
                    HandleDirectMessage((SetTurnMessage) message);
                    break;
				case GameMessageType.PlayersIdMessage:
					HandlePlayersIdMessage((PlayersIdMessage)message);
					break;
            }
        }

		#region Message Handlers

		private void HandleInitMessage(InitializeMessage message)
        {
            CurrentPlayer.Id = message.Id;
        }

        private void HandleTextMessage(TextMessage message)
        {
            TextInChatBox += ((TextMessage)message).Text;
            OnPropertyChanged(nameof(TextInChatBox));
        }

        private void HandleUpdateTableMessage(UpdateTableMessage message)
        {
            MyHand.UpdateCards(message.Hand);
            _isMyTurn = message.IsMyTurn;
            if (message.RoleCard != null)
            {
                RoleImage = message.RoleCard.ImagePath;
                OnPropertyChanged(nameof(RoleImage));
            }
        }

        private void HandleBuildMessage(BuildMessage message)
        {
            // we should update collection view from another thread
            // https://stackoverflow.com/a/18336392/2219089
            Application.Current.Dispatcher.Invoke(delegate
            {
                Map[message.Coordinates.Coordinate_X][message.Coordinates.Coordinate_Y] = message.RouteCard;
            });
            OnPropertyChanged(nameof(Map));
        }

        private void HandleDirectMessage(SetTurnMessage message)
        {
            _isMyTurn = message.IsMyTurn;
        }

		private void HandlePlayersIdMessage(PlayersIdMessage message)
		{
			foreach (string playerId in message.PlayersId)
			{
				Players.Add(new Player { Id = playerId });
			}
			EnemyHand = new PlayerHandViewModel(false, Players[1]);
		}

		#endregion

		private void PrepareMap()
        {
            Map = new ObservableCollection<ObservableCollection<RouteCard>>();
            for (int rowNumber = 0; rowNumber < 6; rowNumber++)
            {
                var row = new List<RouteCard>();
                for (int columnNumber = 0; columnNumber < 9; columnNumber++)
                {
                    row.Add(new RouteCard(rowNumber, columnNumber));
                }
                Map.Add(new ObservableCollection<RouteCard>(row));
            }
        }

        #endregion

    }
}
