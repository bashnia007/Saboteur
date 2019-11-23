using CommonLibrary.Enumerations;
using System;

namespace CommonLibrary.CardsClasses
{
    [Serializable]
    public class HandCard : Card
    {
        public virtual int Angle { get; set; }

        public int SelectedMargin { get; set; }

        public HandCard(int id, string imagePath) : base(id, imagePath)
        {
	        Type = CardType.HandCard;
	        Angle = 0;
	    }

	    public HandCard(int id)
	    {
	        Id = id;
	        Angle = 0;
	    }

	    public HandCard(int x, int y)
	    {
            Coordinates = new Coordinates(x, y);
	        Angle = 0;
	    }

        public HandCard() { }

        public HandCard Rotate()
        {
            Angle = (Angle + 180) % 360;
            return this;
        }
	}
}
