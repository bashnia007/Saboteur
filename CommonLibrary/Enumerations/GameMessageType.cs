using System;

namespace CommonLibrary.Enumerations
{
    [Serializable]
    public enum GameMessageType
    {
        ActionMessage,
        BuildMessage,
        SetTurnMessage,
        InitializeTableMessage,
        InitializeMessage,
        ReadyToPlay,
        TextMessage,
        UpdateTableMessage,
        DestroyConnectionMessage,
        ExploreMessage,
        FoldMessage
    }
}