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
        public int GoldCount { get; }
        public bool IsTroll { get; }
        public bool HasGates { get; }

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

        public CardSet(CardType cardType, string cardImage, RouteType routeType, int count = 1, int goldCount = 0, bool isTroll = false, bool hasGates = false)
        {
            CardType = cardType;
            CardImage = cardImage;
            Count = count;
            RouteType = routeType;
            GoldCount = goldCount;
            IsTroll = isTroll;
            HasGates = hasGates;
        }
    }
}
