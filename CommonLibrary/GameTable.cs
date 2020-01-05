using CommonLibrary.CardsClasses;
using CommonLibrary.GameSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    [Serializable]
    public class GameTable
    {
        public Queue<Card> HandCards { get; }
        public Queue<Card> Roles { get; }

        public GameTable(IGameSet gameSet)
        {
            Roles = ShuffleCards(new List<Card>(gameSet.Roles));
            HandCards = ShuffleCards(PrepareHandCards(gameSet.HandCards));
        }

        private Queue<Card> ShuffleCards(List<Card> initialSet)
        {
            Queue<Card> ShuffledCards = new Queue<Card>();
            int initialSetLength = initialSet.Count;
            Random rnd = new Random();
            while (initialSetLength > 0)
            {
                int number = rnd.Next(initialSetLength);
                var cardByNumber = initialSet[number];
                ShuffledCards.Enqueue(cardByNumber);
                initialSet.RemoveAt(number);
                initialSetLength = initialSet.Count;
            }
            return ShuffledCards;
        }

        private List<Card> PrepareHandCards(List<CardSet> cardSets)
        {
            List<Card> cards = new List<Card>();
            int id = 0;

            foreach (var cardsSet in cardSets)
            {
                switch(cardsSet.CardType)
                {
                    case Enumerations.CardType.RouteCard:
                        for (int i = 0; i < cardsSet.Count; i++)
                        {
                            cards.Add(new RouteCard(id++, cardsSet.RouteType, cardsSet.CardImage, cardsSet.GoldCount, cardsSet.IsTroll, cardsSet.HasGates));
                        };
                        break;
                    case Enumerations.CardType.ActionCard:
                        for (int i = 0; i < cardsSet.Count; i++)
                        {
                            cards.Add(new ActionCard(id++, cardsSet.CardImage, cardsSet.ActionType));
                        };
                        break;
                    case Enumerations.CardType.StairsCard:
                        for (int i = 0; i < cardsSet.Count; i++)
                        {
                            cards.Add(new StairsCard(id++, cardsSet.RouteType, cardsSet.CardImage));
                        };
                        break;
                }
            }

            return cards;
        }
    }
}
