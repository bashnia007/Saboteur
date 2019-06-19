using CommonLibrary.CardsClasses;
using System;
using System.Collections.Generic;
using CommonLibrary;
using CommonLibrary.CardSets;

namespace Server
{
	class CardManager
	{
		public Queue<Card> ShuffleCards(List<Card> initialSet)
		{
			Queue<Card> ShuffledCards = new Queue<Card>();
			int initialSetLength = initialSet.Count;
			Random rnd = new Random();
			while (initialSetLength > 0)
			{
				int number = rnd.Next(initialSetLength);
				var cardByNumber = initialSet[number];
				ShuffledCards.Enqueue(cardByNumber);
				initialSet.RemoveAt(number);
				initialSetLength = initialSet.Count;
			}
			return ShuffledCards;
		}
        
	    public List<GoldCard> SetGoldCards(IGameSet gameSet, List<GoldCard> goldCards)
	    {
	        var shuffledCards = ShuffleCards(new List<Card>(goldCards));

	        var result = new List<GoldCard>();

	        foreach (var coordinate in gameSet.GoldCardCoordinates)
	        {
	            GoldCard card = (GoldCard) shuffledCards.Dequeue();
	            card.Coordinates = coordinate;
	            card.GoldImage = card.ImagePath;
	            card.ImagePath = ImagePaths.GoldBack;
	            result.Add(card);
	        }

	        return result;
	    }
    }
}
