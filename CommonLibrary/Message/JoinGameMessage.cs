using CommonLibrary.Enumerations;
using System;
using System.Collections.Generic;

namespace CommonLibrary.Message
{
    [Serializable]
    public class JoinGameMessage : AbstractGameMessage
    {
        public JoinGameMessage(Guid gameId, string login, List<string> recepients = null) : base(recepients)
        {
            MessageType = GameMessageType.JoinMessage;
            GameId = gameId;
            Login = login;
            IsBroadcast = false;
        }
    }
}
