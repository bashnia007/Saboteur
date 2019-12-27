using CommonLibrary.Enumerations;
using System;

namespace CommonLibrary.Message
{
    [Serializable]
    public class CreateGameMessage : Message
    {
        public GameType GameType { get; }
        public string Creator { get; }

        public CreateGameMessage(GameType gameType, string creator)
        {
            MessageType = GameMessageType.CreateGameMessage;

            GameType = gameType;
            Creator = creator;
        }
    }
}
