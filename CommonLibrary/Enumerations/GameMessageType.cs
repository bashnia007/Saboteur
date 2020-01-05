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
        FoldMessage,
        FoldForFixMessage,
        FindGoldMessage,
        RotateGoldCardMessage,
        UpdateTokensMessage,
        EndGameMessage,
        KeyMessage,

        ClientConnectedMessage,
        RetrieveAllGamesMessage,
        CreateGameMessage,
        JoinMessage,

        StartGameMessage,
        HandInfoMessage
    }
}