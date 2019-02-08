using CommonLibrary.Enumerations;

namespace CommonLibrary.CardsClasses
{
	public class RoleCard: Card
	{
		public RoleType Role { get; set; }

		public RoleCard(RoleType roleType) { Role = roleType; }
	}
}
