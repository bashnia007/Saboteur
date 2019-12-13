using CommonLibrary;
using CommonLibrary.CardsClasses;
using CommonLibrary.Enumerations;
using CommonLibrary.Message;
using Saboteur.Models;
using Saboteur.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using CommonLibrary.Features;

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

        public int CardsInDeck { get; set; }

        private List<HandCard> _cardsToFold;
        private readonly Client _client;
        private bool _isMyTurn;
        private List<GoldCard> _cardsToRotate;

        private bool _canRotate;

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

            _cardsToFold = new List<HandCard>();
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
                        Expore(actionCard, (GoldCard)mapItem);
                        break;
                    default: break;
                }
            }
        }

        private bool CanExecuteBuildTunnelCommand(object obj)
        {
            return _isMyTurn &&
                   SelectedCard != null &&
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
                RouteCard = routeCard,
                RoleType = CurrentPlayer.Role.Role
            });
        }

        private void DestroyConnection(ActionCard actionCard, RouteCard connectionToDestroy)
        {
            _client.SendMessage(new DestroyMessage
            {
                CardId = actionCard.Id,
                Coordinates = connectionToDestroy.Coordinates,
                SenderId = CurrentPlayer.Id,
                RoleType = CurrentPlayer.Role.Role
            });
        }

        private void Expore(ActionCard actionCard, GoldCard cardToOpen)
        {
            _client.SendMessage(new ExploreMessage
            {
                CardId = actionCard.Id,
                Coordinates = cardToOpen.Coordinates,
                SenderId = CurrentPlayer.Id,
                RoleType = CurrentPlayer.Role.Role
            });
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
            if (_cardsToFold.Count == 2)
            {
                _client.SendMessage(new FoldForFixEquipmentMessage
                {
                    Cards = _cardsToFold,
                    ActionType = action.ActionType
                });
            }
            else
            {
                // отправка сообщения, хранящего выбранное действие, ID отправителя и ID игрока, на которого действие направлено
                _client.SendMessage(new ActionMessage
                {
                    ActionType = action.ActionType,
                    Card = (ActionCard)SelectedCard,
                    SenderId = CurrentPlayer.Id,
                    RecepientId = action.Player.Id
                });
            }
        }

        public bool CanExecuteMakeActionCommand(object obj)
        {
            var action = (ActionModel)obj;
            return _isMyTurn && (SelectedCard != null && SelectedCard is ActionCard) || (_cardsToFold.Count == 2);
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
            card.Rotate();
            //card.Angle = (card.Angle + 180) % 360;
            MyHand.UpdateCards(MyHand.Cards.ToList());
        }

        private bool CanExecuteRotateCardCommand(object arg)
        {
            var card = (Card)arg;
            return card is RouteCard;
        }

        #endregion

        #region FoldCommand

        private RelayCommand _foldCommand;

        public ICommand FoldCommand =>
            _foldCommand ?? (_foldCommand = new RelayCommand(ExecuteFoldCommand, CanExecuteFoldCommand));

        private void ExecuteFoldCommand(object o)
        {
            _client.SendMessage(new FoldMessage
            {
                Cards = _cardsToFold
            });

            _cardsToFold = new List<HandCard>();
        }

        private bool CanExecuteFoldCommand(object o)
        {
            return _cardsToFold.Count > 0 && _cardsToFold.Count < 3;
        }

        #endregion

        #region SelectToFoldCommand

        private RelayCommand _selectToFoldCommand;

        public ICommand SelectToFoldCommand => _selectToFoldCommand ?? (_selectToFoldCommand =
                                                   new RelayCommand(ExecuteSelectToFoldCommand,
                                                       CanExecuteSelectToFoldCommand));

        private void ExecuteSelectToFoldCommand(object card)
        {
            var selectedCard = (HandCard) card;
            if (_cardsToFold.Contains(selectedCard))
            {
                _cardsToFold.Remove(selectedCard);
                selectedCard.SelectedMargin = 0;
            }
            else
            {
                _cardsToFold.Add(selectedCard);
                selectedCard.SelectedMargin = -10;
            }
            MyHand.UpdateCards(MyHand.Cards.ToList());
        }

        private bool CanExecuteSelectToFoldCommand(object o)
        {
            return _isMyTurn;
        }

        #endregion

        #region TurnCommand

        private RelayCommand _turnCommand;

        public ICommand TurnCommand =>
            _turnCommand ?? (_turnCommand = new RelayCommand(ExecuteTurnCommand, CanExecuteTurnCommand));

        public void ExecuteTurnCommand(object o)
        {
            var rotateMessage = new RotateGoldCardMessage();
            rotateMessage.CardsToRotate = _cardsToRotate;
            rotateMessage.RoleType = CurrentPlayer.Role.Role;
            _client.SendMessage(rotateMessage);

            _canRotate = false;
        }

        private bool CanExecuteTurnCommand(object o)
        {
            return _canRotate;
        }

        #endregion

        #region RotateGoldCommand

        private RelayCommand _rotateGoldCommand;

        public ICommand RotateGoldCommand =>
            _rotateGoldCommand ?? (_rotateGoldCommand = new RelayCommand(ExecuteRotateGoldCommand, CanExecuteRotateGoldCommand));

        private void ExecuteRotateGoldCommand(object o)
        {
            RouteCard card = (RouteCard)o;
            card.Rotate();
            // we should update collection view from another thread
            // https://stackoverflow.com/a/18336392/2219089
            Application.Current.Dispatcher.Invoke(delegate
            {
                Map[card.Coordinates.Coordinate_Y][card.Coordinates.Coordinate_X] = card;
            });
            Map = new ObservableCollection<ObservableCollection<RouteCard>>(Map);
            OnPropertyChanged(nameof(Map));
        }

        private bool CanExecuteRotateGoldCommand(object o)
        {
            return _canRotate && _cardsToRotate != null && (o is GoldCard && _cardsToRotate.Select(c => c.Id).Contains(((GoldCard)o).Id));
        }

        #endregion

        #region FoldForEquipment

        private RelayCommand _fixEquipmentCommand;

        public ICommand FixEquipmentCommand => _fixEquipmentCommand ?? 
                                               (_fixEquipmentCommand = new RelayCommand(ExecuteFixEquipmentCommand, CanExecuteFixEquipmentCommand));

        private void ExecuteFixEquipmentCommand(object o)
        {

        }

        private bool CanExecuteFixEquipmentCommand(object o)
        {
            return _cardsToFold.Count > 0 && _cardsToFold.Count < 3;
        }

        #endregion

        #endregion

        #region Private methods

        private void ReceivedMessageFromClient(Message message)
        {
            try
            {
                switch (message.MessageType)
                {
                    case GameMessageType.InitializeMessage:
                        HandleInitMessage((InitializeMessage)message);
                        break;
                    case GameMessageType.TextMessage:
                        HandleTextMessage((TextMessage)message);
                        break;
                    case GameMessageType.UpdateTableMessage:
                        HandleUpdateTableMessage((UpdateTableMessage)message);
                        break;
                    case GameMessageType.BuildMessage:
                        HandleBuildMessage((BuildMessage)message);
                        break;
                    case GameMessageType.SetTurnMessage:
                        HandleDirectMessage((SetTurnMessage)message);
                        break;
                    case GameMessageType.InitializeTableMessage:
                        HandleInitializeTableMessage((InitializeTableMessage)message);
                        break;
                    case GameMessageType.ActionMessage:
                        HandleActionMessage((ActionMessage)message);
                        break;
                    case GameMessageType.DestroyConnectionMessage:
                        HandleDestroyMessage((DestroyMessage)message);
                        break;
                    case GameMessageType.ExploreMessage:
                        HandleExploreMessage((ExploreMessage)message);
                        break;
                    case GameMessageType.FindGoldMessage:
                        HandleFindFoldMessage((FindGoldMessage) message);
                        break;
                    case GameMessageType.RotateGoldCardMessage:
                        HandleRotateGoldCardMessage((RotateGoldCardMessage)message);
                        break;
                    case GameMessageType.UpdateTokensMessage:
                        HandleUpdateTokensMessage((UpdateTokensMessage) message);
                        break;
                    case GameMessageType.EndGameMessage:
                        HandleEndGameMessage((EndGameMessage) message);
                        break;
                }

                WriteLog(message);
            }
            catch (Exception e)
            {
                File.AppendAllText("log.txt", "ПОЛУЧЕНИЕ СООБЩЕНИЯ:\n" + e.Message);
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
            CardsInDeck = message.CardsLeftInDeck;
            OnPropertyChanged(nameof(CardsInDeck));
            _isMyTurn = message.IsMyTurn;
            if (message.RoleCard != null)
            {
                CurrentPlayer.Role = message.RoleCard;
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
            CardsInDeck = message.CardsLeftInDeck;
            OnPropertyChanged(nameof(CardsInDeck));
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
            if (!message.IsSuccessful)
            {
                TextInChatBox += "Вы не можете уничтожить эту карту\n";
                return;
            }
            // we should update collection view from another thread
            // https://stackoverflow.com/a/18336392/2219089
            Application.Current.Dispatcher.Invoke(delegate
            {
                Map[message.Coordinates.Coordinate_Y][message.Coordinates.Coordinate_X] = 
                    new RouteCard(message.Coordinates.Coordinate_Y, message.Coordinates.Coordinate_X);
            });
            OnPropertyChanged(nameof(Map));
        }

        private void HandleExploreMessage(ExploreMessage message)
        {
            // we should update collection view from another thread
            // https://stackoverflow.com/a/18336392/2219089
            Application.Current.Dispatcher.Invoke(delegate
                {
                    Map[message.Coordinates.Coordinate_Y][message.Coordinates.Coordinate_X] = message.Card;
                });
            OnPropertyChanged(nameof(Map));
        }

        private void HandleEndGameMessage(EndGameMessage message)
        {
            TextInChatBox += "Blue score: " + message.BlueScore + "\n";
            TextInChatBox += "Green score: " + message.GreenScore + "\n";
            OnPropertyChanged(nameof(TextInChatBox));
        }

        private void HandleFindFoldMessage(FindGoldMessage message)
        {
            TextInChatBox += "Blue score: " + message.BlueGold + "\n";
            TextInChatBox += "Green score: " + message.GreenGold + "\n";
            OnPropertyChanged(nameof(TextInChatBox));
        }

        private void HandleRotateGoldCardMessage(RotateGoldCardMessage rotateGoldCardMessage)
        {
            _canRotate = true;
            TextInChatBox += "Поверните в нужную сторону карты с золотом \n";
            OnPropertyChanged(nameof(TextInChatBox));

            _cardsToRotate = rotateGoldCardMessage.CardsToRotate;
        }

        private void HandleUpdateTokensMessage(UpdateTokensMessage updateTokensMessage)
        {
            foreach (var token in updateTokensMessage.Tokens)
            {
                Application.Current.Dispatcher.Invoke(delegate
                {
                    Map[token.Card.Coordinates.Coordinate_Y][token.Card.Coordinates.Coordinate_X] = token.Card;
                });
                OnPropertyChanged(nameof(Map));
            }
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

        private void WriteLog(Message message)
        {
            switch (message.MessageType)
            {
                case GameMessageType.BuildMessage:
                    var buildMessage = (BuildMessage)message;
                    if (buildMessage.IsSuccessfulBuild)
                        TextInChatBox += $"\nИгрок {(Enum.GetName(typeof(RoleType), buildMessage.RoleType))} построил карту тунеля\n";
                    else TextInChatBox += "Вы не можете построить здесь эту карту\n";
                    break;
                case GameMessageType.DestroyConnectionMessage:
                    var destroyMessage = (DestroyMessage)message;
                    TextInChatBox += $"\nИгрок {(Enum.GetName(typeof(RoleType), destroyMessage.RoleType))} разрушил карту тунеля\n";
                    break;
                case GameMessageType.ExploreMessage:
                    var exploreMessage = (ExploreMessage)message;
                    TextInChatBox += $"\nИгрок {(Enum.GetName(typeof(RoleType), exploreMessage.RoleType))} посмотрел карту тунеля\n";
                    break;
                case GameMessageType.SetTurnMessage:
                    var turnMessage = (SetTurnMessage) message;
                    if (turnMessage.IsMyTurn)
                    {
                        TextInChatBox += $"\nВаш ход\n";
                    }
                    break;
                case GameMessageType.ActionMessage:
                    var actionMessage = (ActionMessage) message;
                    TextInChatBox += $"Игрок {actionMessage.SenderId} сыграл карту {actionMessage.ActionType} на игрока {actionMessage.RecepientId}\n";
                    break;
            }

            OnPropertyChanged(nameof(TextInChatBox));
        }

        #endregion

    }
}
