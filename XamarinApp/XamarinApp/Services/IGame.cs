using CommonLibraryStandard;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinApp.Services
{
    public interface IGame
    {
        List<Player> Players { get; }
        void InitializeTable();

        void StartGame();
    }
}
