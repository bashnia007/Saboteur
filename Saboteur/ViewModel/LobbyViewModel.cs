using ClientLibrary;
using CommonLibrary;
using CommonLibrary.Enumerations;
using CommonLibrary.Message;
using Saboteur.Models;
using Saboteur.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Saboteur.ViewModel
{
    public class LobbyViewModel : ViewModelBase
    {
        #region Properties

        public List<GameModel> Games { get; set; }

        public List<GameType> GameTypes { get; set; }

        public GameType SelectedGameType { get; set; }

        #endregion

        #region Fields

        public readonly LobbyWindow Window;
        private readonly string _login;

        private IClientLogic clientLogic;
        
        #endregion

        #region Constructors

        public LobbyViewModel(string login)
        {
            _login = login;
            Window = new LobbyWindow();
            Window.DataContext = this;

            clientLogic = new ClientLogic();
            clientLogic.EstablishConnection(_login);

            clientLogic.Client.OnReceiveMessageEvent += ReceivedMessageFromClient;
            
            GameTypes = ((GameType[])Enum.GetValues(typeof(GameType))).ToList();
        }

        #endregion

        #region Commads

        #region Refresh games

        private RelayCommand _refreshCommand;

        public ICommand RefreshCommand => _refreshCommand ?? 
            (_refreshCommand = new RelayCommand(ExecuteRefreshCommand, CanExecuteRefreshCommand));

        private void ExecuteRefreshCommand(object o)
        {
            clientLogic.RefreshGamesList();
        }

        private bool CanExecuteRefreshCommand(object o)
        {
            return true;
        }

        #endregion

        #region Create game

        private RelayCommand _createGame;

        public ICommand CreateGameCommand => _createGame ?? (_createGame = new RelayCommand(ExecuteCreateGame, CanExecuteCreateGame));
        
        private void ExecuteCreateGame(object o)
        {
            clientLogic.CreateGame(SelectedGameType, _login);
        }

        private bool CanExecuteCreateGame(object o)
        {
            return true;
        }

        #endregion

        #region Join 

        private RelayCommand _joinCommand;

        public ICommand JoinCommand => _joinCommand ?? (_joinCommand = new RelayCommand(ExecuteJoinCommand, CanExecuteJoinCommand));
        
        private void ExecuteJoinCommand(object obj)
        {
            var game = obj as GameModel;
            clientLogic.JoinGame(game.GameId, _login);
        }

        private bool CanExecuteJoinCommand(object obj)
        {
            return true;
        }

        #endregion

        #endregion

        #region Private methods

        private void ReceivedMessageFromClient(Message message)
        {
            switch(message.MessageType)
            {
                case GameMessageType.ClientConnectedMessage:
                    UpdateGamesList(message as ClientConnectedMessage);
                    break;
                case GameMessageType.RetrieveAllGamesMessage:
                    break;
                case GameMessageType.CreateGameMessage:
                    HandlerGameCreatedMessage(message as CreateGameMessage);
                    break;
                case GameMessageType.JoinMessage:
                    HandlerJoinMessage(message as JoinGameMessage);
                    break;
                default:
                    break;
            }
        }

        private void UpdateGamesList(ClientConnectedMessage message)
        {
            Games = new List<GameModel>();
            foreach(var game in message.Games)
            {
                Games.Add(new GameModel(game));
            }
            OnPropertyChanged(nameof(Games));
        }

        private void HandlerGameCreatedMessage(CreateGameMessage createGameMessage)
        {
            Application.Current.Dispatcher.Invoke(delegate
            {
                var mainViewModel = new MainViewModel(_login);
                mainViewModel.Window.Show();

                Window.Close();
            });
        }

        private void HandlerJoinMessage(JoinGameMessage createGameMessage)
        {
            Application.Current.Dispatcher.Invoke(delegate
            {
                var mainViewModel = new MainViewModel(_login);
                mainViewModel.Window.Show();

                Window.Close();
            });
        }

        #endregion
    }
}
