using System;
using CommonLibrary.CardsClasses;
using CommonLibrary.Enumerations;

namespace CommonLibrary.Message
{
    [Serializable]
    public class ExploreMessage : Message
    {
        public ExploreMessage()
        {
            MessageType = GameMessageType.ExploreMessage;
        }
        public int CardId { get; set; }
        public Coordinates Coordinates { get; set; }
        public GoldCard Card { get; set; }
    }
}
