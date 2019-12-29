using CommonLibrary.Enumerations;
using CommonLibrary.Message;
using System;

namespace ClientLibrary
{
    public delegate void ReceiveMessageDelegate(Message message);

    public interface IClientLogic
    {
        Client Client { get; }
        void EstablishConnection(string login);
        void RefreshGamesList();
        void CreateGame(GameType gameType, string login);
        void JoinGame(Guid gameId, string login);
    }
}
