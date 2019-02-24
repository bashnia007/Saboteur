using CommonLibrary.Enumerations;
using System;

namespace CommonLibrary.CardsClasses
{
    [Serializable]
	public class RoleCard : Card
	{
		public RoleType Role { get; set; }

	    public RoleCard(RoleType roleType)
	    {
	        Role = roleType;

	        switch (roleType)
	        {
                case RoleType.Blue:
                    ImagePath = ImagePaths.BlueDwarf;
                    break;
                case RoleType.Green:
                    ImagePath = ImagePaths.GreenDwarf;
                    break;
	        }
	    }
	}
}
