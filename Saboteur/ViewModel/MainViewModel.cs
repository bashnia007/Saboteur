using CommonLibrary;
using CommonLibrary.CardsClasses;
using CommonLibrary.Enumerations;
using CommonLibrary.Message;
using Saboteur.Models;
using Saboteur.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
            Players.Add(new Player());

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
			_client.OnReceiveMessageEvent += ReceivedMessageFromClient;

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
            if (SelectedCard is RouteCard)
            {
                BuildTunnel(mapItem);
            }

            if (SelectedCard is ActionCard)
            {
                var actionCard = SelectedCard as ActionCard;
                switch (actionCard.Action)
                {
                    case ActionType.DestroyConnection:
                        DestroyConnection(actionCard, mapItem);
                        break;
                    case ActionType.Explore:
                        break;
                    default: break;
                }
            }
        }

        private bool CanExecuteBuildTunnelCommand(object obj)
        {
            return _isMyTurn &&
                   (SelectedCard is RouteCard || 
                   (SelectedCard is ActionCard &&
                   ((ActionCard)SelectedCard).Action == ActionType.DestroyConnection ||
                    ((ActionCard)SelectedCard).Action == ActionType.Explore));
        }

        private void BuildTunnel(RouteCard mapItem)
        {
            var routeCard = SelectedCard as RouteCard;
            routeCard.Coordinates = new Coordinates(mapItem.Coordinates.Coordinate_Y, mapItem.Coordinates.Coordinate_X);
            _client.SendMessage(new BuildMessage
            {
                Coordinates = routeCard.Coordinates,
                SenderId = CurrentPlayer.Id,
                CardId = SelectedCard.Id,
                RouteCard = routeCard
            });
        }

        private void DestroyConnection(ActionCard actionCard, RouteCard connectionToDestroy)
        {
            _client.SendMessage(new DestroyMessage
            {
                CardId = actionCard.Id,
                Coordinates = connectionToDestroy.Coordinates,
                SenderId = CurrentPlayer.Id
            });
        }

        private void Expore(ActionCard actionCard, GoldCard cardToOpen)
        {

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
                ActionType = action.ActionType,
                Card = (ActionCard)SelectedCard,
                SenderId = CurrentPlayer.Id,
                RecepientId = action.Player.Id
            });
        }

        public bool CanExecuteMakeActionCommand(object obj)
        {
            var action = (ActionModel)obj;
            return SelectedCard != null && SelectedCard is ActionCard && _isMyTurn;
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

        #region RotateCommand

        private RelayCommand _rotateCardCommand;

        public ICommand RotateCardCommand => _rotateCardCommand ?? (_rotateCardCommand =
                                                  new RelayCommand(ExecuteRotateCardCommand,
                                                      CanExecuteRotateCardCommand));

        private void ExecuteRotateCardCommand(object obj)
        {
            var card = (HandCard) obj;
            card.Angle = (card.Angle + 180) % 360;
            MyHand.UpdateCards(MyHand.Cards.ToList());
        }

        private bool CanExecuteRotateCardCommand(object arg)
        {
            var card = (Card)arg;
            return card is RouteCard;
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
                case GameMessageType.UpdateTableMessage:
                    HandleUpdateTableMessage((UpdateTableMessage)message);
                    break;
                case GameMessageType.BuildMessage:
                    HandleBuildMessage((BuildMessage) message);
                    break;
                case GameMessageType.SetTurnMessage:
                    HandleDirectMessage((SetTurnMessage) message);
                    break;
                case GameMessageType.InitializeTableMessage:
                    HandleInitializeTableMessage((InitializeTableMessage) message);
                    break;
                case GameMessageType.ActionMessage:
                    HandleActionMessage((ActionMessage) message);
                    break;
                case GameMessageType.DestroyConnectionMessage:
                    HandleDestroyMessage((DestroyMessage) message);
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
            if (!message.IsSuccessfulBuild) return;
            // we should update collection view from another thread
            // https://stackoverflow.com/a/18336392/2219089
            Application.Current.Dispatcher.Invoke(delegate
            {
                Map[message.Coordinates.Coordinate_Y][message.Coordinates.Coordinate_X] = message.RouteCard;
            });
            OnPropertyChanged(nameof(Map));
        }

        private void HandleInitializeTableMessage(InitializeTableMessage message)
        {
            Application.Current.Dispatcher.Invoke(delegate
            {
                foreach (var goldCard in message.GoldCards)
                {
                    Map[goldCard.Coordinates.Coordinate_Y][goldCard.Coordinates.Coordinate_X] = goldCard;
                }

                foreach (var startCard in message.StartCards)
                {
                    Map[startCard.Coordinates.Coordinate_Y][startCard.Coordinates.Coordinate_X] = startCard;
                }

                Players = message.Players;
            });
            OnPropertyChanged(nameof(Map));
            EnemyHand = new PlayerHandViewModel(false, Players.First(pl => pl.Id != CurrentPlayer.Id));
            OnPropertyChanged(nameof(EnemyHand));
        }

        private void HandleDirectMessage(SetTurnMessage message)
        {
            _isMyTurn = message.IsMyTurn;
        }

        private void HandleActionMessage(ActionMessage message)
        {
            if (message.RecepientId == CurrentPlayer.Id)
            {
                MyHand.UpdateEquipment(message.Players.First(pl => pl.Id == CurrentPlayer.Id).BrokenEquipments);
            }
            else
            {
                EnemyHand.UpdateEquipment(message.Players.First(pl => pl.Id == message.RecepientId).BrokenEquipments);
            }
        }

        private void HandleDestroyMessage(DestroyMessage message)
        {
            if (!message.IsSuccessful) return;
            // we should update collection view from another thread
            // https://stackoverflow.com/a/18336392/2219089
            Application.Current.Dispatcher.Invoke(delegate
            {
                Map[message.Coordinates.Coordinate_Y][message.Coordinates.Coordinate_X] = 
                    new RouteCard(message.Coordinates.Coordinate_Y, message.Coordinates.Coordinate_X);
            });
            OnPropertyChanged(nameof(Map));
        }

        private void PrepareMap()
        {
            Map = new ObservableCollection<ObservableCollection<RouteCard>>();
            for (int rowNumber = 0; rowNumber < 7; rowNumber++)
            {
                var row = new List<RouteCard>();
                for (int columnNumber = 0; columnNumber < 11; columnNumber++)
                {
                    row.Add(new RouteCard(rowNumber, columnNumber));
                }
                Map.Add(new ObservableCollection<RouteCard>(row));
            }
        }

        #endregion

    }
}
