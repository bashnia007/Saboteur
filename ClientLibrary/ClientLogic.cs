using CommonLibrary;
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
    }
}
