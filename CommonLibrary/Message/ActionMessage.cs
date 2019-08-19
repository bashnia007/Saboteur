using CommonLibrary.Enumerations;
using System;
using System.Collections.Generic;
using CommonLibrary.CardsClasses;

namespace CommonLibrary.Message
{
    [Serializable]
    public class ActionMessage : Message
    {
        // ID игрока, на которого распространяется действие
        public string RecepientId { get; set; }
        // Выбранное игроком действие
        public ActionType ActionType { get; set; }

        public ActionCard Card { get; set; }

        public int CardId => Card.Id;

        public bool IsSuccessful { get; set; }

        public List<Player> Players { get; set; }
    }
}
