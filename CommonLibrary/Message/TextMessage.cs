using System;

namespace CommonLibrary.Message
{
    [Serializable]
    public class TextMessage : Message
    {
        // текст, который игрок хочет отправить
        public string Text { get; set; }
    }
}
