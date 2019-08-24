using CommonLibrary.CardsClasses;
using System.Collections.Generic;
using CommonLibrary.Features;
using System.Linq;

namespace CommonLibrary
{
	public static class Table
	{
        public static List<RouteCard> OpenedCards = new List<RouteCard>();
        public static List<Player> Players = new List<Player>();
		//List<AbstractPlayer> players = new List<AbstractPlayer>();
		//List<Card> openedCards = new List<Card>();
		public static List<GoldCard> GoldCards = new List<GoldCard>();
        public static List<Token> Tokens = new List<Token>();


        public static void AddCard(RouteCard currentCard)
        {
            var neighbourCards = Table.OpenedCards.Where(c => c.Coordinates.IsNeighbour(currentCard.Coordinates)).ToList();

            var bottomNeighbour = Table.OpenedCards.FirstOrDefault(c =>
                c.Coordinates.Coordinate_X == currentCard.Coordinates.Coordinate_X &&
                c.Coordinates.Coordinate_Y == currentCard.Coordinates.Coordinate_Y + 1);
            if (bottomNeighbour != null && bottomNeighbour.TopConnected)
            {
                currentCard.BottomConnected = true;
                if (currentCard.PassableTroughVertical) currentCard.TopConnected = true;
                if (currentCard.PassableLeft2Bottom) currentCard.LeftConnected = true;
                if (currentCard.PassableRight2Bottom) currentCard.RightConnected = true;
            }

            var topNeighbour = Table.OpenedCards.FirstOrDefault(c =>
                c.Coordinates.Coordinate_X == currentCard.Coordinates.Coordinate_X &&
                c.Coordinates.Coordinate_Y == currentCard.Coordinates.Coordinate_Y - 1);
            if (topNeighbour != null && topNeighbour.BottomConnected)
            {
                currentCard.TopConnected = true;
                if (currentCard.PassableTroughVertical) currentCard.BottomConnected = true;
                if (currentCard.PassableLeft2Top) currentCard.LeftConnected = true;
                if (currentCard.PassableRight2Top) currentCard.RightConnected = true;
            }

            var leftNeighbour = Table.OpenedCards.FirstOrDefault(c =>
                c.Coordinates.Coordinate_X == currentCard.Coordinates.Coordinate_X - 1 &&
                c.Coordinates.Coordinate_Y == currentCard.Coordinates.Coordinate_Y);
            if (leftNeighbour != null && leftNeighbour.RightConnected)
            {
                currentCard.LeftConnected = true;
                if (currentCard.PassableThoughHorizontal) currentCard.RightConnected = true;
                if (currentCard.PassableLeft2Top) currentCard.TopConnected = true;
                if (currentCard.PassableLeft2Bottom) currentCard.BottomConnected = true;
            }

            var rightNeighbour = Table.OpenedCards.FirstOrDefault(c =>
                c.Coordinates.Coordinate_X == currentCard.Coordinates.Coordinate_X + 1 &&
                c.Coordinates.Coordinate_Y == currentCard.Coordinates.Coordinate_Y);
            if (rightNeighbour != null && rightNeighbour.LeftConnected)
            {
                currentCard.RightConnected = true;
                if (currentCard.PassableThoughHorizontal) currentCard.LeftConnected = true;
                if (currentCard.PassableRight2Top) currentCard.TopConnected = true;
                if (currentCard.PassableRight2Bottom) currentCard.BottomConnected = true;
            }

            OpenedCards.Add(currentCard);
        }
    }
}
