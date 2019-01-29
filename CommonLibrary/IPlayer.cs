using System.Collections.Generic;
using CommonLibrary.CardsClasses;

namespace CommonLibrary
{
	interface IPlayer
	{
		int Id { get; set; }
		string Name { get; set; }
		RoleCard Role { get; set; }
		List<Card> Hand { get; set; }
	}
}
