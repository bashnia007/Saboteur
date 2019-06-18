﻿using CommonLibrary.Enumerations;
using System;

namespace CommonLibrary.CardsClasses
{
    [Serializable]
    public class HandCard : Card
    {
        public int Angle { get; set; }

        public HandCard(int id, string imagePath)
	    {
	        Id = id;
	        Type = CardType.HandCard;
	        ImagePath = imagePath;
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
	}
}
