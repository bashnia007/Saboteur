using CommonLibraryStandard.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibraryStandard.Game
{
    [Serializable]
    public class Game
    {
        public Guid GameId { get; }
        public GameType GameType { get; }
        public string Creator { get; }
        public List<Player> Players { get; }
        public int MaxPlayers { get; }

        public Game(GameType gameType, Player creator)
        {
            GameId = Guid.NewGuid();
            GameType = gameType;
            Creator = creator.Name;
            Players = new List<Player>();
            Players.Add(creator);
            
        }
    }
}
