using CommonLibrary.Enumerations;
using System;

namespace CommonLibrary.CardsClasses
{
    [Serializable]
    public class RouteCard: HandCard
	{
		public RouteType RouteType { get; set; }
        
		public RouteCard(int id, string imagePath) : base(id, imagePath) { }

        public RouteCard(int id) : base(id) { }

	    public RouteCard(int x, int y) : base(x, y)
	    {

	    }
	}
}
