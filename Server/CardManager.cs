using CommonLibrary.CardsClasses;
using System;
using System.Collections.Generic;

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
	}
}
