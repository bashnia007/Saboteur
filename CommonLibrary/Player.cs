using CommonLibrary.CardsClasses;
using System;
using System.Collections.Generic;
using CommonLibrary.Enumerations;

namespace CommonLibrary
{
    [Serializable]
	public class Player : AbstractPlayer
	{

        public Player() { Hand = new List<HandCard>(); }
	}
}
