using CommonLibrary.Enumerations;
using CommonLibrary.Launchers;
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
        public AbstractLauncher Launcher { get; }

        public Game(GameType gameType, string creator)
        {
            GameId = Guid.NewGuid();
            GameType = gameType;
            Creator = creator;
            Players = new List<Player>();

            AbstractLauncherFactory launcherFactory;

            switch (gameType)
            {
                case GameType.Duel:
                    MaxPlayers = 2;
                    launcherFactory = new DuelLauncherFactory();
                    break;
                case GameType.Classic:
                    MaxPlayers = 10;
                    launcherFactory = new StandardLauncherFactory();
                    break;
                case GameType.Extended:
                    MaxPlayers = 12;
                    launcherFactory = new ExtendedLauncherFactory();
                    break;
                default:
                    throw new NotImplementedException();
            }

            Launcher = launcherFactory.CreateLauncher();
        }
    }
}
