using System;
using CommonLibrary.Enumerations;

namespace CommonLibrary.CardsClasses
{
    [Serializable]
    public class GoldCard : RouteCard
	{
	    public GoldCard(int id, string imagePath) : base(id, imagePath)
	    {
	        Type = CardType.GoldCard;
	        IsOpen = false;
	    }

        public GoldType GoldType { get; set; }

	    public bool IsOpen
	    {
	        get => _isOpen;
	        set
	        {
	            if (_isOpen == value) return;
	            _isOpen = value;
	            if (_isOpen) ImagePath = GoldImage;
	        }
	    }

        public string GoldImage { get; set; }

	    private bool _isOpen;
	}
}
