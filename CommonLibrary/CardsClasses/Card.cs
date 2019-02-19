using CommonLibrary.Enumerations;
using System;

namespace CommonLibrary.CardsClasses
{
    [Serializable]
    public abstract class Card
    {
	    public int Id { get; set; }
	    public CardType Type { get; set; }
    }
}
