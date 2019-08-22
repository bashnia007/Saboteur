using System;
using CommonLibrary.Enumerations;

namespace CommonLibrary.Message
{
    [Serializable]
    public class FoldMessage : Message
    {
        public FoldMessage()
        {
            MessageType = GameMessageType.ActionMessage;
        }


    }
}
