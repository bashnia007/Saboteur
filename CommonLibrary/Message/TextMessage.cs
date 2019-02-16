using System;
using CommonLibrary.Enumerations;

namespace CommonLibrary.Message
{
    [Serializable]
    public class TextMessage : Message
    {
        public TextMessage()
        {
            MessageType = GameMessageType.TextMessage;
        }
        // текст, который игрок хочет отправить
        public string Text { get; set; }
    }
}
