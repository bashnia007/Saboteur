using CommonLibrary.Enumerations;
using System;

namespace CommonLibrary.Message
{
    [Serializable]
    public class DirectMessage : Message
    {
        public DirectMessage()
        {
            MessageType = GameMessageType.DirectMessage;
            IsDirect = true;
        }
        public bool IsMyTurn => true;
        public string RecepientId { get; set; }
    }
}
