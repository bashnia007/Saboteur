using CommonLibrary.CardsClasses;
using System.Collections.Generic;

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
