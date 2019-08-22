using CommonLibrary.Enumerations;
using System;

namespace CommonLibrary.CardsClasses
{
    [Serializable]
	public class ActionCard : HandCard
	{
		public ActionType Action { get; set; }

	    public ActionCard(int id, string imagePath, ActionType actionType) : base(id, imagePath)
	    {
	        Action = actionType;
	    }
	}
}
