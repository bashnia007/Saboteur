using System;
using CommonLibrary.Enumerations;
using CommonLibrary.Features;
using System.Collections.Generic;

namespace CommonLibrary.Message
{
    [Serializable]
    public class UpdateTokensMessage : Message
    {
        public UpdateTokensMessage(List<Token> tokens)
        {
            Tokens = tokens;
            MessageType = GameMessageType.UpdateTokensMessage;
        }

        public List<Token> Tokens { get; set; }
    }
}
