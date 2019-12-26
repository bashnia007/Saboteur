﻿using CommonLibrary;
using CommonLibrary.Enumerations;
using CommonLibrary.Helpers;
using Saboteur.MVVM;

namespace Saboteur.Models
{
    public class GameModel : ViewModelBase
    {
        public string Creator { get; set; }
        public string GameType { get; set; }
        public string PlayersCount { get; set; }

        public GameModel(Game game)
        {
            Creator = game.Creator;
            PlayersCount = game.Players.Count.ToString();
            GameType = EnumHelper.GetEnumDescription(game.GameType);
        }
    }
}
