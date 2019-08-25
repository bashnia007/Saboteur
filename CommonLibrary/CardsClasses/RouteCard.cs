using CommonLibrary.Enumerations;
using System;
using System.Linq;

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
                ChangeOrientation();
                ChangePassable();
            }
        }

        #region Constructors

        public RouteCard(int id, string imagePath) : base(id, imagePath)
        {

        }

        public RouteCard(int id, RouteType routeType, string imagePath) : base(id, imagePath)
        {
            var cardOrientation = new RouteCardOrientation(routeType);
            JoiningTop = cardOrientation.TopJoining;
            JoiningBottom = cardOrientation.BottomJoining;
            JoiningLeft = cardOrientation.LeftJoining;
            JoiningRight = cardOrientation.RightJoining;

            PassableRight2Bottom = cardOrientation.PassableRight2Bottom;
            PassableRight2Top = cardOrientation.PassableRight2Top;
            PassableTroughVertical = cardOrientation.PassableTroughVertical;
            PassableThoughHorizontal = cardOrientation.PassableThoughHorizontal;
            PassableLeft2Bottom = cardOrientation.PassableLeft2Bottom;
            PassableLeft2Top = cardOrientation.PassableLeft2Top;
        }

        public RouteCard(int id) : base(id) { }

	    public RouteCard(int x, int y) : base(x, y)
	    {
	    }

        #endregion

        #region Параметры возможности присоединения к карточке
        public bool JoiningTop { get; set; }
		public bool JoiningBottom { get; set; }
		public bool JoiningRight { get; set; }
		public bool JoiningLeft { get; set; }
		#endregion

		#region Параметры проходимости туннеля
		public bool PassableThough { get; set; }
		public bool PassableThoughHorizontal { get; set; }
		public bool PassableTroughVertical { get; set; }
		public bool PassableBlueOnly { get; set; }
		public bool PassableGreenOnly { get; set; }
		public bool PassableRight2Top { get; set; }
		public bool PassableRight2Bottom { get; set; }
		public bool PassableLeft2Top { get; set; }
		public bool PassableLeft2Bottom { get; set; }
		public bool NonPassable { get; set; }
        #endregion


        #region Parameters of connection to stairs

        //private bool _leftConnection, _rightConnection, _topConnection, _bottomConnection;

        public bool ConnectedLeft { get; set; }
        public bool ConnectedRight { get; set; }
        public bool ConnectedTop { get; set; }
        public bool ConnectedBottom { get; set; }
        
        #endregion

        public RouteCard NeighbourBottom => Table.OpenedCards.FirstOrDefault(c => 
            c.Coordinates.Coordinate_X == Coordinates.Coordinate_X &&
            c.Coordinates.Coordinate_Y == Coordinates.Coordinate_Y + 1);

        public RouteCard NeighbourTop => Table.OpenedCards.FirstOrDefault(c =>
            c.Coordinates.Coordinate_X == Coordinates.Coordinate_X &&
            c.Coordinates.Coordinate_Y == Coordinates.Coordinate_Y - 1);

        public RouteCard NeighbourLeft => Table.OpenedCards.FirstOrDefault(c =>
            c.Coordinates.Coordinate_X == Coordinates.Coordinate_X - 1 &&
            c.Coordinates.Coordinate_Y == Coordinates.Coordinate_Y);
        
        public RouteCard NeighbourRight => Table.OpenedCards.FirstOrDefault(c =>
            c.Coordinates.Coordinate_X == Coordinates.Coordinate_X + 1 &&
            c.Coordinates.Coordinate_Y == Coordinates.Coordinate_Y);

        private void ChangeOrientation()
        {
            bool temp = JoiningTop;
            JoiningTop = JoiningBottom;
            JoiningBottom = temp;

            temp = JoiningLeft;
            JoiningLeft = JoiningRight;
            JoiningRight = temp;
        }

        private void ChangePassable()
        {
            bool temp = PassableLeft2Top;
            PassableLeft2Top = PassableRight2Bottom;
            PassableRight2Bottom = temp;

            temp = PassableLeft2Bottom;
            PassableLeft2Bottom = PassableRight2Top;
            PassableRight2Top = temp;
        }
	}
}
