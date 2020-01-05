using CommonLibrary;
using CommonLibrary.Enumerations;
using CommonLibrary.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLibrary
{
    public class ClientLogic : IClientLogic
    {
        public Client Client { get; }

        public ClientLogic()
        {
            Client = new Client();
        }

        public void EstablishConnection(string login)
        {
            Client.EstablishConnection();
            Client.SendMessage(new ClientConnectedMessage
            {
                Login = login
            });
        }

        public void RefreshGamesList()
        {
            Client.SendMessage(new RetrieveAllGamesMessage());
        }

        public void CreateGame(GameType gameType, string login)
        {
            Client.SendMessage(new CreateGameMessage(gameType, login));
        }

        public void JoinGame(Guid gameId, string login)
        {
            Client.SendMessage(new JoinGameMessage(gameId, login));
        }

        public void StartGame(Guid gameId)
        {
            Client.SendMessage(new StartGameMessage(gameId));
        }
    }
}
