using CommonLibrary.Enumerations;

namespace CommonLibrary.CardSets
{
    public class CardSet
    {
        public CardType CardType { get; set; }
        public string CardImage { get; }
        public int Count { get; }

        public CardSet(CardType cardType, string cardImage, int count)
        {
            CardType = cardType;
            CardImage = cardImage;
            Count = count;
        }
    }
}
