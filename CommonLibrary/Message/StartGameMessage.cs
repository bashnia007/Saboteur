using CommonLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Message
{
    [Serializable]
    public class StartGameMessage : Message
    {
        public StartGameMessage(Guid gameId)
        {
            MessageType = GameMessageType.StartGameMessage;
            GameId = gameId;
        }
    }
}
