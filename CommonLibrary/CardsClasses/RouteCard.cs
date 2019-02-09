using CommonLibrary.Enumerations;

namespace CommonLibrary.CardsClasses
{
	public class RouteCard: HandCard
	{
		public RouteType Type { get; set; }
		public RouteCard(int id) : base(id) { }
	}
}
