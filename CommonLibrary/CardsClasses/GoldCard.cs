using System;
using CommonLibrary.Enumerations;

namespace CommonLibrary.CardsClasses
{
    [Serializable]
    public class GoldCard : RouteCard
	{
	    public GoldCard(int id, RouteType routeType, string imagePath, int goldCount = 0) : base(id, routeType, imagePath, goldCount)
	    {
	        Type = CardType.GoldCard;
	        IsOpen = false;
	        Gold = goldCount;
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
