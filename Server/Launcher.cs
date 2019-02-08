using CommonLibrary;
using CommonLibrary.CardsClasses;
using CommonLibrary.Enumerations;
using System.Collections.Generic;

namespace Server
{
	public class Launcher
	{
		public List<IPlayer> Players { get; set; }
		public List<RoleCard> RoleCards { get; set; }

		public Launcher()
		{
			Players = new List<IPlayer>();
			Players.Add(new Player());
			Players.Add(new Player());

			RoleCards = new List<RoleCard>();
			RoleCards.Add(new RoleCard(RoleType.Blue));
			RoleCards.Add(new RoleCard(RoleType.Green));
					
		}

		public void Shuffle()
		{
		} 
	}
}