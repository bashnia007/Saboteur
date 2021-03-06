﻿using CommonLibrary.CardsClasses;
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


        public static void AddCard(RouteCard currentCard, RoleType roleType = RoleType.None)
        {
            OpenedCards.Add(currentCard);
            if (currentCard.IsTroll)
            {
                UseToken(currentCard, roleType);
            }
        }

	    public static void UpdateAllConnections(RoleType roleType = RoleType.None)
	    {
            Logger.Write($"Updating connections for {roleType} started");

            var visitedCards = new List<RouteCard>();
            var cardsToCheck = new Queue<RouteCard>();

	        foreach (var card in OpenedCards)
	        {
	            if (!StartCards.Contains(card) && !(card is StairsCard))
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
                Logger.Write("Start card was added to start list");
            }

	        foreach (var openedCard in OpenedCards)
	        {
                if (openedCard is StairsCard stairsCard)
                {
                    if (openedCard.JoiningBottom) openedCard.ConnectionBottom = stairsCard.Color;
                    if (openedCard.JoiningTop) openedCard.ConnectionTop = stairsCard.Color;
                    if (openedCard.JoiningLeft) openedCard.ConnectionLeft = stairsCard.Color;
                    if (openedCard.JoiningRight) openedCard.ConnectionRight = stairsCard.Color;

                    cardsToCheck.Enqueue(stairsCard);
                    Logger.Write("Stairs card was added to start list");
                }
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

	                if (bottomCard.Gold > 0 && !bottomCard.IsTaken && 
	                    ((int)bottomCard.GoldConnections.FromTop & (int) roleType) != 0 &&
	                    ((int) bottomCard.ConnectionTop & (int) roleType) != 0)
	                {
                        UseToken(bottomCard, roleType);
                    }
                }

	            var topCard = card.NeighbourTop;
	            // если есть соединение сверху
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

	                if (topCard.Gold > 0 && !topCard.IsTaken &&
	                    ((int)topCard.GoldConnections.FromBottom & (int)roleType) != 0 &&
	                    ((int)topCard.ConnectionBottom & (int)roleType) != 0)
	                {
	                    UseToken(topCard, roleType);
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

	                if (leftCard.Gold > 0 && !leftCard.IsTaken && 
	                    ((int)leftCard.GoldConnections.FromRight & (int)roleType) != 0 &&
	                    ((int)leftCard.ConnectionRight & (int)roleType) != 0)
                    {
                        UseToken(leftCard, roleType);
                    }
                }

	            var rightCard = card.NeighbourRight;
	            // если есть соединение справа
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

	                if (rightCard.Gold > 0 && !rightCard.IsTaken && 
	                    ((int)rightCard.GoldConnections.FromLeft & (int)roleType) != 0 &&
	                    ((int)rightCard.ConnectionRight & (int)roleType) != 0)
	                {
	                    UseToken(rightCard, roleType);
                    }
	            }
            }

	        Logger.Write($"Updating connections for {roleType} finished");
        }

	    private static void UseToken(RouteCard card, RoleType roleType)
	    {
	        var token = new Token
	        {
	            Card = card,
	            Role = roleType
	        };

            Tokens.Add(token);
	        card.IsTaken = true;
	        card.Token = token;

	        Logger.Write($"Token for {roleType} was used. Remaining tokens: {8 - Tokens.Count}");
        }

        public static void SetKey(RouteCard card)
        {
            if (card.PassabilityHorizontal != ConnectionType.None) card.PassabilityHorizontal = ConnectionType.Both;
            if (card.PassabilityLeft2Bottom != ConnectionType.None) card.PassabilityLeft2Bottom = ConnectionType.Both;
            if (card.PassabilityLeft2Top != ConnectionType.None) card.PassabilityLeft2Top = ConnectionType.Both;
            if (card.PassabilityRight2Bottom != ConnectionType.None) card.PassabilityRight2Bottom = ConnectionType.Both;
            if (card.PassabilityRight2Top != ConnectionType.None) card.PassabilityRight2Top = ConnectionType.Both;
            if (card.PassabilityVertical != ConnectionType.None) card.PassabilityVertical = ConnectionType.Both;

            if (card.ConnectionBottom != ConnectionType.None) card.ConnectionBottom = ConnectionType.Both;
            if (card.ConnectionLeft != ConnectionType.None) card.ConnectionLeft = ConnectionType.Both;
            if (card.ConnectionRight != ConnectionType.None) card.ConnectionRight = ConnectionType.Both;
            if (card.ConnectionTop != ConnectionType.None) card.ConnectionTop = ConnectionType.Both;
        }
    }
}
