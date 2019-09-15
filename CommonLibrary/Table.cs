using CommonLibrary.CardsClasses;
using System.Collections.Generic;
using CommonLibrary.Features;
using System.Linq;
using CommonLibrary.Enumerations;

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
            OpenedCards.Add(currentCard);
        }

	    public static void UpdateAllConnections()
	    {
            var visitedCards = new List<RouteCard>();
            var cardsToCheck = new Queue<RouteCard>();

	        foreach (var card in OpenedCards)
	        {
	            if (!StartCards.Contains(card))
	            {
	                card.ConnectionBottom = ConnectionType.None;
	                card.ConnectionLeft = ConnectionType.None;
	                card.ConnectionRight = ConnectionType.None;
	                card.ConnectionTop = ConnectionType.None;
	            }
	        }

	        foreach (StartCard startCard in StartCards)
	        {
	            switch (startCard.Role)
	            {
                    case RoleType.Blue:
                        startCard.ConnectionBottom = ConnectionType.Blue;
                        startCard.ConnectionLeft = ConnectionType.Blue;
                        startCard.ConnectionRight = ConnectionType.Blue;
                        startCard.ConnectionTop = ConnectionType.Blue;
                        break;
                    case RoleType.Green:
                        startCard.ConnectionBottom = ConnectionType.Green;
                        startCard.ConnectionLeft = ConnectionType.Green;
                        startCard.ConnectionRight = ConnectionType.Green;
                        startCard.ConnectionTop = ConnectionType.Green;
                        break;
	            }
	            cardsToCheck.Enqueue(startCard);
            }

	        while (cardsToCheck.Count > 0)
	        {
	            var card = cardsToCheck.Dequeue();

	            var bottomCard = card.NeighbourBottom;
                // если есть соединение снизу
                if (card.JoiningBottom && bottomCard != null && bottomCard.JoiningTop)
	            {
	                if (bottomCard.ConnectionTop != card.ConnectionBottom && bottomCard.ConnectionTop != ConnectionType.Both)
	                {
	                    bottomCard.ConnectionTop |= card.ConnectionBottom;
	                    bottomCard.ConnectionLeft |= bottomCard.PassabilityLeft2Top & card.ConnectionBottom;
	                    bottomCard.ConnectionBottom |= bottomCard.PassabilityVertical & card.ConnectionBottom;
	                    bottomCard.ConnectionRight |= bottomCard.PassabilityRight2Top & card.ConnectionBottom;

	                    cardsToCheck.Enqueue(bottomCard);
                    }
                }

	            var topCard = card.NeighbourTop;
	            // если есть соединение снизу
	            if (card.JoiningTop && topCard != null && topCard.JoiningBottom)
	            {
	                // если здесь еще не были
	                if (topCard.ConnectionBottom != card.ConnectionTop && topCard.ConnectionBottom != ConnectionType.Both)
	                {
	                    topCard.ConnectionBottom |= card.ConnectionTop;
	                    topCard.ConnectionRight |= topCard.PassabilityRight2Bottom & card.ConnectionTop;
	                    topCard.ConnectionLeft |= topCard.PassabilityLeft2Bottom & card.ConnectionTop;
                        topCard.ConnectionTop |= topCard.PassabilityVertical & card.ConnectionTop;

	                    cardsToCheck.Enqueue(topCard);
	                }
	            }

	            var leftCard = card.NeighbourLeft;
	            // если есть соединение слева
	            if (card.JoiningLeft && leftCard != null && leftCard.JoiningRight)
	            {
	                // если здесь еще не были
	                if (leftCard.ConnectionRight != card.ConnectionLeft && leftCard.ConnectionRight != ConnectionType.Both)
	                {
	                    leftCard.ConnectionRight |= card.ConnectionLeft;
	                    leftCard.ConnectionBottom |= topCard.PassabilityRight2Bottom & card.ConnectionLeft;
	                    leftCard.ConnectionLeft |= topCard.PassabilityHorizontal & card.ConnectionLeft;
                        leftCard.ConnectionTop |= topCard.PassabilityRight2Top & card.ConnectionLeft;

	                    cardsToCheck.Enqueue(leftCard);
	                }
	            }

	            var rightCard = card.NeighbourRight;
	            // если есть соединение слева
	            if (card.JoiningRight && rightCard != null && rightCard.JoiningLeft)
	            {
	                // если здесь еще не были
	                if (rightCard.ConnectionLeft != card.ConnectionRight && rightCard.ConnectionLeft != ConnectionType.Both)
                    {
	                    rightCard.ConnectionLeft |= card.ConnectionRight;
	                    rightCard.ConnectionBottom |= rightCard.PassabilityLeft2Bottom & card.ConnectionRight;
	                    rightCard.ConnectionRight |= rightCard.PassabilityHorizontal & card.ConnectionRight;
                        rightCard.ConnectionTop |= rightCard.PassabilityLeft2Top & card.ConnectionRight;

	                    cardsToCheck.Enqueue(rightCard);
	                }
	            }
            }
	    }
    }
}
