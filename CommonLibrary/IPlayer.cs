using System.Collections.Generic;
using CommonLibrary.CardsClasses;

namespace CommonLibrary
{
	public abstract class IPlayer
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public RoleCard Role { get; set; }
		public List<Card> Hand { get; set; }
	}
}
