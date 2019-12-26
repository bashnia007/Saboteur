using CommonLibrary;
using System.Collections.Generic;

namespace Server
{
    public static class GameManager
    {
        private static List<Game> _games;

        static GameManager()
        {
            _games = new List<Game>();
        }

        public static List<Game> RecieveAllGames()
        {
            return _games;
        }

        public static Game CreateGame(Game game)
        {
            Logger.Write($"Game with id={game.GameId} was created");
            _games.Add(game);
            return game;
        }

        public static void CloseGame(string gameId)
        {
            Logger.Write($"Game with id={gameId} was closed");
            _games.RemoveAll(g => g.GameId == gameId);
        }
    }
}
