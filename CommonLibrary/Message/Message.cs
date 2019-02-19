using CommonLibrary.Enumerations;
using System;

namespace CommonLibrary.Message
{
    [Serializable]
    public abstract class Message
    {
        public string SenderId { get; set; }
		public string Login { get; set; }
        public GameMessageType MessageType { get; set; }
        public bool IsBroadcast { get; set; }

        protected Message()
        {
            IsBroadcast = true;
        }
    }
}
