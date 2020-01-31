using CommonLibraryStandard.Enums;
using CommonLibraryStandard.Game;
using CommonLibraryStandard.Helpers;
using System;
using XamarinApp.MVVM;

namespace XamarinApp.Models
{
    public class GameModel : ViewModelBase
    {
        public Guid GameId { get; set; }
        public string Creator { get; set; }
        public string GameType { get; set; }
        public int PlayersCount { get; set; }

        public GameModel(Game game)
        {
            Creator = game.Creator;
            PlayersCount = game.Players.Count;
            GameType = EnumHelper.GetEnumDescription(game.GameType);
            GameId = game.GameId;
        }
    }
}
