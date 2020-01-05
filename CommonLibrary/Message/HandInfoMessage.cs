using CommonLibrary.CardsClasses;
using CommonLibrary.Enumerations;
using System;
using System.Collections.Generic;

namespace CommonLibrary.Message
{
    [Serializable]
    public class HandInfoMessage : Message
    {
        public RoleCard Role { get; }
        public List<HandCard> HandCards { get; }

        public HandInfoMessage(RoleCard roleCard, List<HandCard> handCards, string recepientId)
        {
            MessageType = GameMessageType.HandInfoMessage;
            IsBroadcast = false;
            IsPrivateForEveryone = true;

            Role = roleCard;
            HandCards = handCards;
            RecepientId = recepientId;
        }
    }
}
