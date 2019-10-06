using System;
using CommonLibrary.Enumerations;

namespace CommonLibrary.Message
{
    [Serializable]
    public class DestroyMessage : Message
    {
        public DestroyMessage()
        {
            MessageType = GameMessageType.DestroyConnectionMessage;
        }
        public int CardId { get; set; }
        public Coordinates Coordinates { get; set; }
        public bool IsSuccessful { get; set; }
        public RoleType RoleType { get; set; }
    }
}
