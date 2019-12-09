using CommonLibrary.Enumerations;
using System;

namespace CommonLibrary.Message
{
    [Serializable]
    public class EndGameMessage : Message
    {
        public EndGameMessage()
        {
            MessageType = GameMessageType.EndGameMessage;
        }

        public int GreenScore { get; set; }
        public int BlueScore { get; set; }
    }
}
