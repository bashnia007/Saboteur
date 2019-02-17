using System;
using CommonLibrary.Enumerations;

namespace CommonLibrary.Message
{
    [Serializable]
    public abstract class Message
    {
        public string SenderId { get; set; }
        public GameMessageType MessageType { get; set; }
        public bool IsBroadcast { get; set; }

        protected Message()
        {
            IsBroadcast = true;
        }
    }
}
