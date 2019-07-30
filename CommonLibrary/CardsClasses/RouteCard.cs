using CommonLibrary.Enumerations;
using System;

namespace CommonLibrary.CardsClasses
{
    [Serializable]
    public class RouteCard: HandCard
    {
        private int _angle;
		//public RouteType RouteType { get; set; }

        public override int Angle
        {
            get { return _angle;}
            set
            {
                _angle = value;
                bool temp = TopJoining;
                TopJoining = BottomJoining;
                BottomJoining = temp;

                temp = LeftJoining;
                LeftJoining = RightJoining;
                RightJoining = temp;
            }
        }

        public RouteCard(int id, string imagePath) : base(id, imagePath)
        {

        }

        public RouteCard(int id, RouteType routeType, string imagePath) : base(id, imagePath)
        {
            var cardOrientation = new RouteCardOrientation(routeType);
            TopJoining = cardOrientation.TopJoining;
            BottomJoining = cardOrientation.BottomJoining;
            LeftJoining = cardOrientation.LeftJoining;
            RightJoining = cardOrientation.RightJoining;
        }

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

	    public RouteCard(int x, int y) : base(x, y)
	    {
	    }
	}
}
