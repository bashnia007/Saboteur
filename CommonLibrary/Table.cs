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
                if (currentCard.PassableTroughVerticalBlue) currentCard.ConnectedTopBlue = true;
                if (currentCard.PassableTroughVerticalGreen) currentCard.ConnectedTopGreen = true;

                if (currentCard.PassableLeft2Bottom) currentCard.ConnectedLeft = true;
                if (currentCard.PassableLeft2BottomBlue) currentCard.ConnectedLeftBlue = true;
                if (currentCard.PassableLeft2BottomGreen) currentCard.ConnectedLeftGreen = true;

                if (currentCard.PassableRight2Bottom) currentCard.ConnectedRight = true;
                if (currentCard.PassableRight2BottomBlue) currentCard.ConnectedRightBlue = true;
                if (currentCard.PassableRight2BottomGreen) currentCard.ConnectedRightGreen = true;
            }

            var topNeighbour = Table.OpenedCards.FirstOrDefault(c =>
                c.Coordinates.Coordinate_X == currentCard.Coordinates.Coordinate_X &&
                c.Coordinates.Coordinate_Y == currentCard.Coordinates.Coordinate_Y - 1);
            if (topNeighbour != null && topNeighbour.ConnectedBottom)
            {
                currentCard.ConnectedTop = true;
                if (currentCard.PassableTroughVertical) currentCard.ConnectedBottom = true;
                if (currentCard.PassableTroughVerticalBlue) currentCard.ConnectedBottomBlue = true;
                if (currentCard.PassableTroughVerticalGreen) currentCard.ConnectedBottomGreen = true;

                if (currentCard.PassableLeft2Top) currentCard.ConnectedLeft = true;
                if (currentCard.PassableLeft2TopBlue) currentCard.ConnectedLeftBlue = true;
                if (currentCard.PassableLeft2TopGreen) currentCard.ConnectedLeftGreen = true;

                if (currentCard.PassableRight2Top) currentCard.ConnectedRight = true;
                if (currentCard.PassableRight2TopBlue) currentCard.ConnectedRightBlue = true;
                if (currentCard.PassableRight2TopGreen) currentCard.ConnectedRightGreen = true;
            }

            var leftNeighbour = Table.OpenedCards.FirstOrDefault(c =>
                c.Coordinates.Coordinate_X == currentCard.Coordinates.Coordinate_X - 1 &&
                c.Coordinates.Coordinate_Y == currentCard.Coordinates.Coordinate_Y);
            if (leftNeighbour != null && leftNeighbour.ConnectedRight)
            {
                currentCard.ConnectedLeft = true;
                if (currentCard.PassableThoughHorizontal) currentCard.ConnectedRight = true;
                if (currentCard.PassableThoughHorizontalBlue) currentCard.ConnectedRightBlue = true;
                if (currentCard.PassableThoughHorizontalGreen) currentCard.ConnectedRightGreen = true;

                if (currentCard.PassableLeft2Top) currentCard.ConnectedTop = true;
                if (currentCard.PassableLeft2TopBlue) currentCard.ConnectedTopBlue = true;
                if (currentCard.PassableLeft2TopGreen) currentCard.ConnectedTopGreen = true;

                if (currentCard.PassableLeft2Bottom) currentCard.ConnectedBottom = true;
                if (currentCard.PassableLeft2BottomBlue) currentCard.ConnectedBottomBlue = true;
                if (currentCard.PassableLeft2BottomGreen) currentCard.ConnectedBottomGreen = true;
            }

            var rightNeighbour = Table.OpenedCards.FirstOrDefault(c =>
                c.Coordinates.Coordinate_X == currentCard.Coordinates.Coordinate_X + 1 &&
                c.Coordinates.Coordinate_Y == currentCard.Coordinates.Coordinate_Y);
            if (rightNeighbour != null && rightNeighbour.ConnectedLeft)
            {
                currentCard.ConnectedRight = true;
                if (currentCard.PassableThoughHorizontal) currentCard.ConnectedLeft = true;
                if (currentCard.PassableThoughHorizontalBlue) currentCard.ConnectedLeftBlue = true;
                if (currentCard.PassableThoughHorizontalGreen) currentCard.ConnectedLeftGreen = true;

                if (currentCard.PassableRight2Top) currentCard.ConnectedTop = true;
                if (currentCard.PassableRight2TopBlue) currentCard.ConnectedTopBlue = true;
                if (currentCard.PassableRight2TopGreen) currentCard.ConnectedTopGreen = true;

                if (currentCard.PassableRight2Bottom) currentCard.ConnectedBottom = true;
                if (currentCard.PassableRight2BottomBlue) currentCard.ConnectedBottomBlue = true;
                if (currentCard.PassableRight2BottomGreen) currentCard.ConnectedBottomGreen = true;
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
	                if (card.NeighbourBottom.PassableTroughVerticalBlue) card.NeighbourBottom.ConnectedBottomBlue = true;
	                if (card.NeighbourBottom.PassableTroughVerticalGreen) card.NeighbourBottom.ConnectedBottomGreen = true;

	                if (card.NeighbourBottom.PassableRight2Top) card.NeighbourBottom.ConnectedRight = true;
	                if (card.NeighbourBottom.PassableRight2TopBlue) card.NeighbourBottom.ConnectedRightBlue = true;
	                if (card.NeighbourBottom.PassableRight2TopGreen) card.NeighbourBottom.ConnectedRightGreen = true;

	                if (card.NeighbourBottom.PassableLeft2Top) card.NeighbourBottom.ConnectedLeft = true;
	                if (card.NeighbourBottom.PassableLeft2TopBlue) card.NeighbourBottom.ConnectedLeftBlue = true;
	                if (card.NeighbourBottom.PassableLeft2TopGreen) card.NeighbourBottom.ConnectedLeftGreen = true;

	                cardsToCheck.Enqueue(card.NeighbourBottom);
                }

	            // если есть соединение сверху, которое еще не посещали
	            if (card.ConnectedTop && card.NeighbourTop != null &&
	                card.NeighbourTop.JoiningBottom && !card.NeighbourTop.ConnectedBottom)
	            {
	                card.NeighbourTop.ConnectedBottom = true;
	                if (card.NeighbourTop.PassableTroughVertical) card.NeighbourTop.ConnectedBottom = true;
	                if (card.NeighbourTop.PassableTroughVerticalBlue) card.NeighbourTop.ConnectedBottomBlue = true;
	                if (card.NeighbourTop.PassableTroughVerticalGreen) card.NeighbourTop.ConnectedBottomGreen = true;

	                if (card.NeighbourTop.PassableRight2Bottom) card.NeighbourTop.ConnectedRight = true;
	                if (card.NeighbourTop.PassableRight2BottomBlue) card.NeighbourTop.ConnectedRightBlue = true;
	                if (card.NeighbourTop.PassableRight2BottomGreen) card.NeighbourTop.ConnectedRightGreen = true;

	                if (card.NeighbourTop.PassableLeft2Bottom) card.NeighbourTop.ConnectedLeft = true;
	                if (card.NeighbourTop.PassableLeft2BottomBlue) card.NeighbourTop.ConnectedLeftBlue = true;
	                if (card.NeighbourTop.PassableLeft2BottomGreen) card.NeighbourTop.ConnectedLeftGreen = true;

	                cardsToCheck.Enqueue(card.NeighbourTop);
	            }

	            // если есть соединение слева, которое еще не посещали
	            if (card.ConnectedLeft && card.NeighbourLeft != null &&
	                card.NeighbourLeft.JoiningRight && !card.NeighbourLeft.ConnectedRight)
	            {
	                card.NeighbourLeft.ConnectedRight = true;
	                if (card.NeighbourLeft.PassableThoughHorizontal) card.NeighbourLeft.ConnectedLeft = true;
	                if (card.NeighbourLeft.PassableThoughHorizontalBlue) card.NeighbourLeft.ConnectedLeftBlue = true;
	                if (card.NeighbourLeft.PassableThoughHorizontalGreen) card.NeighbourLeft.ConnectedLeftGreen = true;

	                if (card.NeighbourLeft.PassableRight2Top) card.NeighbourLeft.ConnectedTop = true;
	                if (card.NeighbourLeft.PassableRight2TopBlue) card.NeighbourLeft.ConnectedTopBlue = true;
	                if (card.NeighbourLeft.PassableRight2TopGreen) card.NeighbourLeft.ConnectedTopGreen = true;

	                if (card.NeighbourLeft.PassableRight2Bottom) card.NeighbourLeft.ConnectedBottom = true;
	                if (card.NeighbourLeft.PassableRight2BottomBlue) card.NeighbourLeft.ConnectedBottomBlue = true;
	                if (card.NeighbourLeft.PassableRight2BottomGreen) card.NeighbourLeft.ConnectedBottomGreen = true;

	                cardsToCheck.Enqueue(card.NeighbourLeft);
	            }

	            // если есть соединение справа, которое еще не посещали
	            if (card.ConnectedRight && card.NeighbourRight != null &&
	                card.NeighbourRight.JoiningLeft && !card.NeighbourRight.ConnectedLeft)
	            {
	                card.NeighbourRight.ConnectedLeft = true;
	                if (card.NeighbourRight.PassableThoughHorizontal) card.NeighbourRight.ConnectedRight = true;
	                if (card.NeighbourRight.PassableThoughHorizontalBlue) card.NeighbourRight.ConnectedRightBlue = true;
	                if (card.NeighbourRight.PassableThoughHorizontalGreen) card.NeighbourRight.ConnectedRightGreen = true;

	                if (card.NeighbourRight.PassableLeft2Top) card.NeighbourRight.ConnectedTop = true;
	                if (card.NeighbourRight.PassableLeft2TopBlue) card.NeighbourRight.ConnectedTopBlue = true;
	                if (card.NeighbourRight.PassableLeft2TopGreen) card.NeighbourRight.ConnectedTopGreen = true;

	                if (card.NeighbourRight.PassableLeft2Bottom) card.NeighbourRight.ConnectedBottom = true;
	                if (card.NeighbourRight.PassableLeft2BottomBlue) card.NeighbourRight.ConnectedBottomBlue = true;
	                if (card.NeighbourRight.PassableLeft2BottomGreen) card.NeighbourRight.ConnectedBottomGreen = true;

	                cardsToCheck.Enqueue(card.NeighbourRight);
	            }
            }
	    }
    }
}
