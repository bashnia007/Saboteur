using CommonLibrary.Enumerations;
using System;
using System.Collections.Generic;

namespace CommonLibrary.Message
{
    [Serializable]
    public class RetrieveAllGamesMessage : Message
    {
        public RetrieveAllGamesMessage()
        {
            MessageType = GameMessageType.RetrieveAllGamesMessage;
        }

        public List<Game> Games { get; set; }
    }
}
