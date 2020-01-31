using System;
using System.Collections.Generic;
using System.Text;
using CommonLibraryStandard;

namespace XamarinApp.Services
{
    class MultiPlayerGame : IGame
    {
        public MultiPlayerGame()
        {
            Players = new List<Player>();
        }
        public List<Player> Players { get; }

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
