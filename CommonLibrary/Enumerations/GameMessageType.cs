using System;

namespace CommonLibrary.Enumerations
{
    [Serializable]
    public enum GameMessageType
    {
        ActionMessage,
        BuildMessage,
        SetTurnMessage,
        GameStarted,
        InitializeMessage,
        ReadyToPlay,
        TextMessage,
        UpdateTableMessage,
		PlayersIdMessage,
	}
}