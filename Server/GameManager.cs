using CommonLibrary;
using CommonLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public static Game RecieveGame(Guid gameId)
        {
            var result = _games.FirstOrDefault(g => g.GameId == gameId);
            if (result == null) Logger.Write($"Can't find game with id = {gameId}");
            return result;
        }

        public static Game CreateGame(Game game)
        {
            Logger.Write($"Game with id={game.GameId} was created");
            _games.Add(game);
            return game;
        }

        public static Game CreateGame(GameType gameType, Player creator)
        {
            Game newGame = new Game(gameType, creator);
            Logger.Write($"Game with id={newGame.GameId} was created");
            _games.Add(newGame);
            return newGame;
        }

        public static bool JoinGame(Guid gameId, Player player)
        {
            var game = _games.FirstOrDefault(g => g.GameId == gameId);

            if (game == null)
            {
                Logger.Write($"Game with id={gameId} wasn't found", LogLevel.Error);
                return false;
            }

            return game.JoinPlayer(player);
        }

        public static void CloseGame(Guid gameId)
        {
            Logger.Write($"Game with id={gameId} was closed");
            _games.RemoveAll(g => g.GameId == gameId);
        }
    }
}
