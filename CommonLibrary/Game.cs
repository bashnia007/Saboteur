using CommonLibrary.Enumerations;
using System;
using System.Collections.Generic;

namespace CommonLibrary
{
    [Serializable]
    public class Game
    {
        public Guid GameId { get; }
        public GameType GameType { get; }
        public string Creator { get; }
        public List<Player> Players { get; }
        public int MaxPlayers { get; }

        public Game(GameType gameType, string creator)
        {
            GameId = Guid.NewGuid();
            GameType = gameType;
            Creator = creator;
            Players = new List<Player>();

            switch(gameType)
            {
                case GameType.Duel:
                    MaxPlayers = 2;
                    break;
                case GameType.Classic:
                    MaxPlayers = 10;
                    break;
                case GameType.Extended:
                    MaxPlayers = 12;
                    break;
            }
        }
    }
}
