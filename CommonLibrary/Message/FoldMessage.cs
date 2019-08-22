using System;
using System.Collections.Generic;
using CommonLibrary.CardsClasses;
using CommonLibrary.Enumerations;

namespace CommonLibrary.Message
{
    [Serializable]
    public class FoldMessage : Message
    {
        public FoldMessage()
        {
            MessageType = GameMessageType.FoldMessage;
        }

        public List<HandCard> Cards { get; set; }
    }
}
