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
		public Coordinates Coordinates { get; set; }

        protected Card(int id, string imagePath)
        {
            Id = id;
            ImagePath = imagePath;
        }

        protected Card() { }
    }
}
