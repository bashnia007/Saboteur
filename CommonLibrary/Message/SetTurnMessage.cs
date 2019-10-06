using CommonLibrary.Enumerations;
using System;

namespace CommonLibrary.Message
{
    [Serializable]
    public class SetTurnMessage : Message
    {
        public SetTurnMessage()
        {
            MessageType = GameMessageType.SetTurnMessage;
            IsTurnMessage = true;
        }
        public bool IsMyTurn => true;
        public string RecepientId { get; set; }
        public int CardsLeftInDeck { get; set; }
    }
}
