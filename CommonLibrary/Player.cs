using CommonLibrary.CardsClasses;
using System.Collections.Generic;

namespace CommonLibrary
{
	public class Player : IPlayer
	{
		public Player() { Hand = new List<HandCard>(); }
	}
}
