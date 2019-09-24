using CommonLibrary.Enumerations;
using System;

namespace CommonLibrary.Message
{
    [Serializable]
    public class EndGameMessage : Message
    {
        public EndGameMessage()
        {
            MessageType = GameMessageType.BuildMessage;
        }

        public int GreenScore { get; set; }
        public int BlueScore { get; set; }
    }
}
