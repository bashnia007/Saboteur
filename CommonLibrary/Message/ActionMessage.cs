using CommonLibrary.Enumerations;
using System;
using System.Collections.Generic;

namespace CommonLibrary.Message
{
    [Serializable]
    public class ActionMessage : Message
    {
        // ID игрока, на которого распространяется действие
        public string RecepientId { get; set; }
        // Выбранное игроком действие
        public ActionType ActionType { get; set; }

        public bool IsSuccessful { get; set; }

        public List<Player> Players { get; set; }
    }
}
