using System;
using CommonLibrary.Enumerations;

namespace CommonLibrary.Message
{
    [Serializable]
    public class FindGoldMessage : Message
    {
        public FindGoldMessage()
        {
            MessageType = GameMessageType.FindGoldMessage;
        }

        public int BlueGold { get; set; }
        public int GreenGold { get; set; }
    }
}
