using CommonLibrary.Enumerations;

namespace CommonLibrary.CardSets
{
    public class CardSet
    {
        public CardType CardType { get; set; }
        public string CardImage { get; }
        public int Count { get; }
        public RouteType RouteType { get; }
        public ActionType ActionType { get; }

        public CardSet(CardType cardType, string cardImage, int count = 1)
        {
            CardType = cardType;
            CardImage = cardImage;
            Count = count;
        }

        public CardSet(CardType cardType, string cardImage, ActionType actionType, int count = 1)
        {
            CardType = cardType;
            CardImage = cardImage;
            Count = count;
            ActionType = actionType;
        }

        public CardSet(CardType cardType, string cardImage, RouteType routeType, int count = 1)
        {
            CardType = cardType;
            CardImage = cardImage;
            Count = count;
            RouteType = routeType;
        }
    }
}
