using System;

namespace CommonLibrary.Enumerations
{
    [Serializable]
    public enum GameMessageType
    {
        TextMessage,
        ReadyToPlay,
        GameStarted,
        ActionMessage,
        BuildMessage,
        InitializeMessage,
        UpdateTableMessage
    }
}