using CommonLibrary.CardsClasses;
using CommonLibrary.Enumerations;
using System;

namespace CommonLibrary.Message
{
    [Serializable]
    public class KeyMessage : Message
    {
        public KeyMessage()
        {
            MessageType = GameMessageType.KeyMessage;
        }
        public int CardId { get; set; }
        public Coordinates Coordinates { get; set; }
        public RouteCard Card { get; set; }
        public RoleType RoleType { get; set; }
    }
}
