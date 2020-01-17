using CommonLibraryStandard;
using CommonLibraryStandard.Enums;
using CommonLibraryStandard.Game;
using System;
using System.Collections.Generic;
using System.Text;
using XamarinApp.Models;
using XamarinApp.MVVM;

namespace XamarinApp.ViewModels
{
    public class GamesViewModel : ViewModelBase
    {
        public List<GameModel> Games { get; set; }
        public GameModel SelectedGame { get; set; }

        public GamesViewModel()
        {
            Games = new List<GameModel>();
            var superPlayer = new Player("ololo");
            Games.Add(new GameModel(new Game(GameType.Duel, superPlayer)));
            Games.Add(new GameModel(new Game(GameType.Classic, superPlayer)));
            Games.Add(new GameModel(new Game(GameType.Extended, superPlayer)));
            Games.Add(new GameModel(new Game(GameType.Duel, superPlayer)));
        }
    }
}
