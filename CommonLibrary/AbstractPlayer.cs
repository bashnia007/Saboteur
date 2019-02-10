using CommonLibrary.CardsClasses;
using System.Collections.Generic;

namespace CommonLibrary
{
	public abstract class AbstractPlayer
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public RoleCard Role { get; set; }
		public List<HandCard> Hand { get; set; }
	}
}
