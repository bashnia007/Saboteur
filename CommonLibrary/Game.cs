using CommonLibrary.Enumerations;
using System;
using System.Collections.Generic;

namespace CommonLibrary
{
    [Serializable]
    public class Game
    {
        public string GameId { get; set; }
        public GameType GameType { get; set; }
        public string Creator { get; set; }
        public List<Player> Players { get; set; }
    }
}
