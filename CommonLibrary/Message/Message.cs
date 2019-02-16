using System;
using CommonLibrary.Enumerations;

namespace CommonLibrary.Message
{
    [Serializable]
    public abstract class Message
    {
        public int SenderId { get; set; }
        public GameMessageType MessageType { get; set; }
    }
}
