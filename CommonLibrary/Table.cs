using System.Collections.Generic;
using CommonLibrary.CardsClasses; 

namespace CommonLibrary
{
	class Table
	{
		List<IPlayer> players = new List<IPlayer>();
		List<Card> openedCards = new List<Card>();
		List<GoldCard> goldCards = new List<GoldCard>();
		Queue<HandCard> unusedCards = new Queue<HandCard>(); 
	}
}
