using System;
using CommonLibrary.Enumerations;

namespace CommonLibrary.Message
{
    [Serializable]
    public class ActionMessage : Message
    {
        public int SenderId { get; set; }
        public int RecepientId { get; set; }
        public ActionType ActionType { get; set; }
    }
}
