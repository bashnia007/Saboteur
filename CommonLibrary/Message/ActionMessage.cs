using System;
using CommonLibrary.Enumerations;

namespace CommonLibrary.Message
{
    [Serializable]
    public class ActionMessage : Message
    {
        // ID игрока, на которого распространяется действие
        public int RecepientId { get; set; }
        // Выбранное игроком действие
        public ActionType ActionType { get; set; }
    }
}
