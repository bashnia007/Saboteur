using ClientLibrary;
using CommonLibrary;
using CommonLibrary.Enumerations;
using CommonLibrary.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saboteur.ViewModel
{
    public class MainViewModel2
    {
        #region Properties

        public readonly MainWindow Window;
        public Player CurrentPlayer { get; set; }
        public string Login { get; set; }

        #endregion

        #region Fields

        private IClientLogic _clientLogic;
        private Guid _gameId;
        private ClientLibrary.Table _table;

        #endregion

        #region Constructors

        public MainViewModel2(string login, Guid gameId, IClientLogic clientLogic)
        {
            Login = login;
            _gameId = gameId;
            _clientLogic = clientLogic;

            Window = new MainWindow();
            Window.DataContext = this;

            Init();
        }
        public MainViewModel2(string login, Guid gameId, IClientLogic clientLogic, List<string> playerNames) : this(login, gameId, clientLogic)
        {
            foreach (var name in playerNames)
            {
                _table.AddPlayer(new Player(name));
            }
        }

        #endregion

        #region Private methods

        private void Init()
        {
            _clientLogic.Client.OnReceiveMessageEvent += ReceivedMessageFromClient;

            CurrentPlayer = new Player(Login);

            _table = new ClientLibrary.Table();
            _table.AddPlayer(CurrentPlayer);

        }

        private void ReceivedMessageFromClient(Message message)
        {
            switch (message.MessageType)
            {
                case GameMessageType.JoinMessage:
                    break;
            }
        }

        private void HandleJoinMessage(JoinGameMessage joinGameMessage)
        {
            _table.AddPlayer(new Player(joinGameMessage.Login));
        }

        #endregion
    }
}
