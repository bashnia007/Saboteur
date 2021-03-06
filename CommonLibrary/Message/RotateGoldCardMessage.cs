﻿using CommonLibrary.CardsClasses;
using System;
using CommonLibrary.Enumerations;
using System.Collections.Generic;

namespace CommonLibrary.Message
{
    [Serializable]
    public class RotateGoldCardMessage : Message
    {
        public RotateGoldCardMessage()
        {
            MessageType = GameMessageType.RotateGoldCardMessage;
            CardsToRotate = new List<GoldCard>();
            IsBroadcast = false;
        }
        public List<GoldCard> CardsToRotate { get; set; }
        public RoleType RoleType { get; set; }
    }
}
