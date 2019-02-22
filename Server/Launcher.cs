using CommonLibrary;
using CommonLibrary.CardsClasses;
using CommonLibrary.CardSets;
using CommonLibrary.Enumerations;
using System.Collections.Generic;

namespace Server
{
	public class Launcher
	{
		CardManager cardManager;
		public List<AbstractPlayer> Players { get; set; }
		public List<Card> RoleCards { get; set; }
		public List<Card> HandCards { get; set; }

		public Launcher(List<string> playerIds)
		{
			cardManager = new CardManager();

		    Players = new List<AbstractPlayer>();
		    foreach (var player in playerIds)
		    {
		        Players.Add(new Player
		        {
                    Id = player
		        });
            }


            RoleCards = new List<Card>();
			RoleCards.Add(new RoleCard(RoleType.Blue));
			RoleCards.Add(new RoleCard(RoleType.Green));

			HandCards = new List<Card>();
		    CreateCardSet(new One2OneGameSet());

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

	    private void CreateCardSet(IGameSet gameSet)
	    {
	        int cardId = 0;
	        foreach (var cardSet in gameSet.CardSets)
	        {
	            for (int i = 0; i < cardSet.Count; i++)
	            {
	                switch (cardSet.CardType)
	                {
                        case CardType.RouteCard:
                            HandCards.Add(new RouteCard(cardId++, cardSet.CardImage));
                            break;
                        case CardType.ActionCard:
                            HandCards.Add(new ActionCard(cardId++, cardSet.CardImage));
                            break;
	                }
	            }
	        }
	    }
	}
}