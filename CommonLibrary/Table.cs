using System.Collections.Generic;
using CommonLibrary.CardsClasses; 

namespace CommonLibrary
{
	public class Table
	{
		List<AbstractPlayer> players = new List<AbstractPlayer>();
		List<Card> openedCards = new List<Card>();
		List<GoldCard> goldCards = new List<GoldCard>();
		Queue<HandCard> unusedCards = new Queue<HandCard>();
	}
}
