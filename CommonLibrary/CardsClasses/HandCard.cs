using CommonLibrary.Enumerations;
using System;

namespace CommonLibrary.CardsClasses
{
    [Serializable]
    public class HandCard : Card
	{
	    public HandCard(int id, string imagePath)
	    {
	        Id = id;
	        Type = CardType.HandCard;
	        ImagePath = imagePath;
	    }

	    public HandCard(int id)
	    {
	        Id = id;
	    }

	    public HandCard(int x, int y)
	    {
            Coordinates = new Coordinates(x, y);
	    }
	}
}
