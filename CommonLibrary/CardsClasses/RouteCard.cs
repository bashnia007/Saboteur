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

		#region Параметры возможности присоединения к карточке
		public bool TopJoining { get; set; }
		public bool BottomJoining { get; set; }
		public bool RightJoining { get; set; }
		public bool LeftJoining { get; set; }
		#endregion

		#region Параметры проходимости туннеля
		public bool PassableThough { get; set; }
		public bool PassableThoughHorisontal { get; set; }
		public bool PassableTroughVertical { get; set; }
		public bool PassableBlueOnly { get; set; }
		public bool PassableGreenOnly { get; set; }
		public bool PassableRight2Top { get; set; }
		public bool PassableRight2Bottom { get; set; }
		public bool PassableLeft2Top { get; set; }
		public bool PassableLeft2Bottom { get; set; }
		public bool NonPassable { get; set; }
		#endregion
	}
}
