using System;
using System.Collections.Generic;
using CommonLibrary.CardsClasses;
using CommonLibrary.Enumerations;

namespace CommonLibrary.Message
{
    [Serializable]
    public class UpdateTableMessage : Message
    {
        public UpdateTableMessage()
        {
            MessageType = GameMessageType.UpdateTableMessage;
            Hand = new List<HandCard>();

        }
        public List<HandCard> Hand { get; set; }
        public RoleCard RoleCard { get; set; }
    }
}
