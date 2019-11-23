using CommonLibrary.Enumerations;
using CommonLibrary.Features;
using System;
using System.Drawing;

namespace CommonLibrary.CardsClasses
{
    [Serializable]
    public abstract class Card
    {
	    public int Id { get; set; }
	    public CardType Type { get; set; }
        public string ImagePath { get; set; }
		public Coordinates Coordinates { get; set; }
        public Token Token { get; set; }

        public Color TokenColor { get; set; }

        protected Card(int id, string imagePath)
        {
            Token = new Token
            {
                Role = RoleType.None
            };
            Id = id;
            ImagePath = imagePath;
        }

        protected Card() { }
    }
}
