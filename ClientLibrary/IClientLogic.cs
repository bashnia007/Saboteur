using CommonLibrary;
using CommonLibrary.Enumerations;
using CommonLibrary.Message;
using System.Collections.Generic;

namespace ClientLibrary
{
    public delegate void ReceiveMessageDelegate(Message message);

    public interface IClientLogic
    {
        Client Client { get; }
        void EstablishConnection(string login);
        void RefreshGamesList();
        void CreateGame(GameType gameType, string login);
    }
}
