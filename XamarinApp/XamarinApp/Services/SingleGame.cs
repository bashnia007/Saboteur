using System;
using System.Collections.Generic;
using System.Text;
using CommonLibraryStandard;

namespace XamarinApp.Services
{
    public class SingleGame : IGame
    {
        public SingleGame()
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
