using System;
using System.Collections.Generic;
using System.Text;
using CommonLibraryStandard;
using XamarinApp.Bots;

namespace XamarinApp.Services
{
    public class SingleGame : IGame
    {
        private int _playersCount;
        public List<Player> Players { get; }

        public SingleGame(int playersCount = 0)
        {
            Players = new List<Player>();
            _playersCount = playersCount;
        }

        private void PreparePlayers()
        {
            Players.Add(new Player());
            Players.AddRange(BotGenerator.GenerateBots(_playersCount - 1));
        }

        public void InitializeTable()
        {
            throw new NotImplementedException();
        }

        public void StartGame()
        {
            throw new NotImplementedException();
        }
    }
}
