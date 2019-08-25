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
        public static List<RouteCard> StartCards = new List<RouteCard>();


        public static void AddCard(RouteCard currentCard)
        {
            var neighbourCards = Table.OpenedCards.Where(c => c.Coordinates.IsNeighbour(currentCard.Coordinates)).ToList();

            var bottomNeighbour = Table.OpenedCards.FirstOrDefault(c =>
                c.Coordinates.Coordinate_X == currentCard.Coordinates.Coordinate_X &&
                c.Coordinates.Coordinate_Y == currentCard.Coordinates.Coordinate_Y + 1);
            if (bottomNeighbour != null && bottomNeighbour.ConnectedTop)
            {
                currentCard.ConnectedBottom = true;
                if (currentCard.PassableTroughVertical) currentCard.ConnectedTop = true;
                if (currentCard.PassableLeft2Bottom) currentCard.ConnectedLeft = true;
                if (currentCard.PassableRight2Bottom) currentCard.ConnectedRight = true;
            }

            var topNeighbour = Table.OpenedCards.FirstOrDefault(c =>
                c.Coordinates.Coordinate_X == currentCard.Coordinates.Coordinate_X &&
                c.Coordinates.Coordinate_Y == currentCard.Coordinates.Coordinate_Y - 1);
            if (topNeighbour != null && topNeighbour.ConnectedBottom)
            {
                currentCard.ConnectedTop = true;
                if (currentCard.PassableTroughVertical) currentCard.ConnectedBottom = true;
                if (currentCard.PassableLeft2Top) currentCard.ConnectedLeft = true;
                if (currentCard.PassableRight2Top) currentCard.ConnectedRight = true;
            }

            var leftNeighbour = Table.OpenedCards.FirstOrDefault(c =>
                c.Coordinates.Coordinate_X == currentCard.Coordinates.Coordinate_X - 1 &&
                c.Coordinates.Coordinate_Y == currentCard.Coordinates.Coordinate_Y);
            if (leftNeighbour != null && leftNeighbour.ConnectedRight)
            {
                currentCard.ConnectedLeft = true;
                if (currentCard.PassableThoughHorizontal) currentCard.ConnectedRight = true;
                if (currentCard.PassableLeft2Top) currentCard.ConnectedTop = true;
                if (currentCard.PassableLeft2Bottom) currentCard.ConnectedBottom = true;
            }

            var rightNeighbour = Table.OpenedCards.FirstOrDefault(c =>
                c.Coordinates.Coordinate_X == currentCard.Coordinates.Coordinate_X + 1 &&
                c.Coordinates.Coordinate_Y == currentCard.Coordinates.Coordinate_Y);
            if (rightNeighbour != null && rightNeighbour.ConnectedLeft)
            {
                currentCard.ConnectedRight = true;
                if (currentCard.PassableThoughHorizontal) currentCard.ConnectedLeft = true;
                if (currentCard.PassableRight2Top) currentCard.ConnectedTop = true;
                if (currentCard.PassableRight2Bottom) currentCard.ConnectedBottom = true;
            }

            OpenedCards.Add(currentCard);
        }

	    public static void UpdateAllConnections()
	    {
            var visitedCards = new List<RouteCard>();
            var cardsToCheck = new Queue<RouteCard>();

	        foreach (var card in Table.OpenedCards)
	        {
	            if (!StartCards.Contains(card))
	            {
	                card.ConnectedBottom = false;
	                card.ConnectedTop = false;
	                card.ConnectedLeft = false;
	                card.ConnectedRight = false;
	            }
	        }

	        foreach (var startCard in StartCards)
	        {
	            cardsToCheck.Enqueue(startCard);
            }

	        while (cardsToCheck.Count > 0)
	        {
	            var card = cardsToCheck.Dequeue();

                // если есть соединение снизу, которое еще не посещали
	            if (card.ConnectedBottom && card.NeighbourBottom != null && 
	                card.NeighbourBottom.JoiningTop && !card.NeighbourBottom.ConnectedTop)
	            {
	                card.NeighbourBottom.ConnectedTop = true;
	                if (card.NeighbourBottom.PassableTroughVertical) card.NeighbourBottom.ConnectedBottom = true;
	                if (card.NeighbourBottom.PassableRight2Top) card.NeighbourBottom.ConnectedRight = true;
	                if (card.NeighbourBottom.PassableLeft2Top) card.NeighbourBottom.ConnectedLeft = true;

	                cardsToCheck.Enqueue(card.NeighbourBottom);
                }

	            // если есть соединение сверху, которое еще не посещали
	            if (card.ConnectedTop && card.NeighbourTop != null &&
	                card.NeighbourTop.JoiningBottom && !card.NeighbourTop.ConnectedBottom)
	            {
	                card.NeighbourTop.ConnectedBottom = true;
	                if (card.NeighbourTop.PassableTroughVertical) card.NeighbourTop.ConnectedBottom = true;
	                if (card.NeighbourTop.PassableRight2Bottom) card.NeighbourTop.ConnectedRight = true;
	                if (card.NeighbourTop.PassableLeft2Bottom) card.NeighbourTop.ConnectedLeft = true;

	                cardsToCheck.Enqueue(card.NeighbourTop);
	            }

	            // если есть соединение слева, которое еще не посещали
	            if (card.ConnectedLeft && card.NeighbourLeft != null &&
	                card.NeighbourLeft.JoiningRight && !card.NeighbourLeft.ConnectedRight)
	            {
	                card.NeighbourLeft.ConnectedRight = true;
	                if (card.NeighbourLeft.PassableThoughHorizontal) card.NeighbourLeft.ConnectedLeft = true;
	                if (card.NeighbourLeft.PassableRight2Top) card.NeighbourLeft.ConnectedTop = true;
	                if (card.NeighbourLeft.PassableRight2Bottom) card.NeighbourLeft.ConnectedBottom = true;

	                cardsToCheck.Enqueue(card.NeighbourLeft);
	            }

	            // если есть соединение справа, которое еще не посещали
	            if (card.ConnectedRight && card.NeighbourRight != null &&
	                card.NeighbourRight.JoiningLeft && !card.NeighbourRight.ConnectedLeft)
	            {
	                card.NeighbourRight.ConnectedLeft = true;
	                if (card.NeighbourRight.PassableThoughHorizontal) card.NeighbourRight.ConnectedRight = true;
	                if (card.NeighbourRight.PassableLeft2Top) card.NeighbourRight.ConnectedTop = true;
	                if (card.NeighbourRight.PassableLeft2Bottom) card.NeighbourRight.ConnectedBottom = true;

	                cardsToCheck.Enqueue(card.NeighbourRight);
	            }
            }
	    }
    }
}
