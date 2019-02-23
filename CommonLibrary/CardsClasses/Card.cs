using CommonLibrary.Enumerations;
using System;

namespace CommonLibrary.CardsClasses
{
    [Serializable]
    public abstract class Card
    {
	    public int Id { get; set; }
	    public CardType Type { get; set; }
        public string ImagePath { get; set; }
		public int Coordinate_X { get; set; }
		public int Coordinate_Y { get; set; }
    }
}
