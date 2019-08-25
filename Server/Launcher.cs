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
        public List<GoldCard> GoldCards { get; set; }
        public Queue<Card> ShuffledHandCards { get; set; }
        public List<GoldCard> GoldCardsForGame { get; set; }
        public List<RouteCard> StartCards { get; set; }

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
                Table.Players.Add(new Player
                {
                    Id = player,
                    BrokenEquipments = new List<Equipment>()
                });
            }


            RoleCards = new List<Card>();
			RoleCards.Add(new RoleCard(RoleType.Blue));
			RoleCards.Add(new RoleCard(RoleType.Green));

			HandCards = new List<Card>();
            GoldCards = new List<GoldCard>();

		    var gameSet = new One2OneGameSet();
            CreateCardSet(gameSet);
		    GoldCardsForGame = cardManager.SetGoldCards(gameSet, GoldCards);
		    StartCards = gameSet.StartCards;
		    foreach (var startCard in StartCards)
		    {
		        startCard.ConnectedLeft = true;
		        startCard.ConnectedRight = true;
		        startCard.ConnectedTop = true;
		        startCard.ConnectedBottom = true;
		    }
            Table.StartCards.AddRange(StartCards);
            Table.OpenedCards.AddRange(StartCards);
		    Table.GoldCards = GoldCardsForGame;
		}

		public void ProvideRolesForPlayers()
		{
			Queue<Card> shuffledRoleCards = cardManager.ShuffleCards(RoleCards);
			Players[0].Role = (RoleCard)shuffledRoleCards.Dequeue();
			Players[1].Role = (RoleCard)shuffledRoleCards.Dequeue();
		}

		public void ProvideHandCardsForPlayers()
		{
		    ShuffledHandCards = cardManager.ShuffleCards(HandCards);
			int k = 0;

			while (k != 12)
			{
				foreach (Player player in Players)
				{
					player.Hand.Add((HandCard)ShuffledHandCards.Dequeue());
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
                        case CardType.GoldCard:
                            GoldCards.Add(new GoldCard(cardId++, cardSet.CardImage));
                            break;
                        case CardType.RouteCard:
                            HandCards.Add(new RouteCard(cardId++, cardSet.RouteType, cardSet.CardImage));
                            break;
                        case CardType.ActionCard:
                            HandCards.Add(new ActionCard(cardId++, cardSet.CardImage, cardSet.ActionType));
                            break;
	                }
	            }
	        }
	    }
    }
}