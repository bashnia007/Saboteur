using CommonLibrary;
using CommonLibrary.CardsClasses;
using CommonLibrary.Enumerations;
using System.Collections.Generic;

namespace Server
{
	public class Launcher
	{
		CardManager cardManager;
		public List<IPlayer> Players { get; set; }
		public List<Card> RoleCards { get; set; }
		public List<Card> HandCards { get; set; }

		public Launcher()
		{
			cardManager = new CardManager();

			Players = new List<IPlayer>();
			Players.Add(new Player());
			Players.Add(new Player());

			RoleCards = new List<Card>();
			RoleCards.Add(new RoleCard(RoleType.Blue));
			RoleCards.Add(new RoleCard(RoleType.Green));

			HandCards = new List<Card>();
			for (int i = 0; i <= 30; i++)
			{
				HandCards.Add(new HandCard(i));
			}
		}

		public void ProvideRolesForPlayers()
		{
			Queue<Card> shuffledRoleCards = cardManager.ShuffleCards(RoleCards);
			Players[0].Role = (RoleCard)shuffledRoleCards.Dequeue();
			Players[1].Role = (RoleCard)shuffledRoleCards.Dequeue();
		}

		public void ProvideHandCardsForPlayers()
		{
			Queue<Card> shuffledHandCards = cardManager.ShuffleCards(HandCards);
			int k = 0;

			while (k != 12)
			{
				foreach (Player player in Players)
				{
					player.Hand.Add((HandCard)shuffledHandCards.Dequeue());
					k++;
				}
			}
		}
	}
}