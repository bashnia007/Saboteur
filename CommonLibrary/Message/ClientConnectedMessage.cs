using CommonLibrary.Enumerations;
using System;
using System.Collections.Generic;

namespace CommonLibrary.Message
{
    [Serializable]
    public class ClientConnectedMessage : Message
    {
        public ClientConnectedMessage()
        {
            MessageType = GameMessageType.ClientConnectedMessage;
            Games = new List<Game>();
        }
        public List<Game> Games { get; set; }
    }
}
