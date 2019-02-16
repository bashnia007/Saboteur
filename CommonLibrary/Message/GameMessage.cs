using CommonLibrary.Enumerations;

namespace CommonLibrary.Message
{
    public class GameMessage : Message
    {
        public GameMessageType MessageType { get; set; }
    }
}
