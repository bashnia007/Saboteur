using CommonLibrary.Enumerations;

namespace CommonLibrary.CardsClasses
{
	public class ActionCard : HandCard
	{
		public ActionType Action { get; set; }
		public ActionCard(int id, string imagePath) : base(id, imagePath) { }
	}
}
