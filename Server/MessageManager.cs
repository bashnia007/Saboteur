using CommonLibrary.Enumerations;
using CommonLibrary.Message;

namespace Server
{
    public class MessageManager
    {
        public void HandleMessage(Message message)
        {
            var type = message.MessageType;
            switch (type)
            {
                case GameMessageType.TextMessage: break;
                case GameMessageType.ReadyToPlay:

                    break;
            }
        }
    }
}
