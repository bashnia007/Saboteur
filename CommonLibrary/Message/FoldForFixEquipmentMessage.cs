using CommonLibrary.CardsClasses;
using CommonLibrary.Enumerations;
using System;
using System.Collections.Generic;

namespace CommonLibrary.Message
{
    [Serializable]
    public class FoldForFixEquipmentMessage : Message
    {
        public FoldForFixEquipmentMessage()
        {
            MessageType = GameMessageType.FoldForFixMessage;
        }

        public List<HandCard> Cards { get; set; }
        // Выбранное игроком действие
        public ActionType ActionType { get; set; }
    }
}
