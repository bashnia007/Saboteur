using System;
using System.Collections.Generic;
using CommonLibrary.CardsClasses;
using CommonLibrary.Enumerations;

namespace CommonLibrary.Message
{
    [Serializable]
    public class InitializeTableMessage : Message
    {
        public InitializeTableMessage()
        {
            MessageType = GameMessageType.InitializeTableMessage;
        }
        public List<GoldCard> GoldCards { get; set; }
        public List<RouteCard> StartCards { get; set; }
    }
}
