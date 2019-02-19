using CommonLibrary.Enumerations;
using System;

namespace CommonLibrary.Message
{
    [Serializable]
    public class InitializeMessage : Message
    {
        public InitializeMessage()
        {
            MessageType = GameMessageType.InitializeMessage;
        }
        public string Login { get; set; }
        public string Id { get; set; }
    }
}
