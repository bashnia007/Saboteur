using ClientLibrary;
using CommonLibrary;
using CommonLibrary.Enumerations;
using CommonLibrary.Message;
using Saboteur.Models;
using Saboteur.MVVM;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Saboteur.ViewModel
{
    public class LobbyViewModel : ViewModelBase
    {
        #region Properties

        public List<GameModel> Games { get; set; }

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

        #endregion
    }
}
