using CommonLibrary.Enumerations;
using System;

namespace CommonLibrary.Message
{
    [Serializable]
    public class JoinGameMessage : Message
    {
        public JoinGameMessage(Guid gameId, string login)
        {
            MessageType = GameMessageType.JoinMessage;
            GameId = gameId;
            Login = login;
        }
    }
}
