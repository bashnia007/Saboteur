using System;

namespace CommonLibrary.Message
{
    [Serializable]
    public class GameMessage : Message
    {
        public bool IsMyTurn { get; set; }
    }
}
