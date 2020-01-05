using CommonLibrary.Enumerations;
using System;

namespace CommonLibrary.Message
{
    [Serializable]
    public abstract class Message
    {
        public Guid GameId { get; set; }
        public string SenderId { get; set; }
		public string Login { get; set; }
        public GameMessageType MessageType { get; set; }
        public bool IsBroadcast { get; set; }
        public bool IsTurnMessage { get; set; }
        public bool IsPrivateForEveryone { get; set; }
        public string RecepientId { get; set; }

        protected Message()
        {
            IsBroadcast = true;
        }
    }
}
