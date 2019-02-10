using CommonLibrary.CardsClasses;
using System.Collections.Generic;

namespace CommonLibrary
{
	public class Player : AbstractPlayer
	{
		public Player() { Hand = new List<HandCard>(); }
	}
}
