using CommonLibrary.CardsClasses;
using System;
using System.Collections.Generic;
using CommonLibrary.Enumerations;

namespace CommonLibrary
{
    [Serializable]
    public abstract class AbstractPlayer
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public RoleCard Role { get; set; }
		public List<HandCard> Hand { get; set; }
	    public List<Equipment> BrokenEquipments { get; set; }
    }
}
