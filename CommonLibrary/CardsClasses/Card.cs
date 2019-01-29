using CommonLibrary.Enumerations;

namespace CommonLibrary.CardsClasses
{
    public abstract class Card
    {
	    public int Id { get; set; }
	    public CardType Type { get; set; }
    }
}
