using CommonLibrary.CardsClasses;
using CommonLibrary.Enumerations;
using System;
using System.Collections.Generic;

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
