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

            PassabilityVertical = cardOrientation.PassabilityVertical;
            PassabilityHorizontal = cardOrientation.PassabilityHorizontal;
            PassabilityLeft2Top = cardOrientation.PassabilityLeft2Top;
            PassabilityRight2Top = cardOrientation.PassabilityRight2Top;
            PassabilityLeft2Bottom = cardOrientation.PassabilityLeft2Bottom;
            PassabilityRight2Bottom = cardOrientation.PassabilityRight2Bottom;
        }

        public RouteCard(int id) : base(id) { }

	    public RouteCard(int x, int y) : base(x, y)
	    {
	    }

        #endregion

        public int Gold { get; set; }

        #region Параметры возможности присоединения к карточке
        public bool JoiningTop { get; set; }
		public bool JoiningBottom { get; set; }
		public bool JoiningRight { get; set; }
		public bool JoiningLeft { get; set; }
		#endregion
        /*
		#region Параметры проходимости туннеля
		public bool PassableThoughHorizontal { get; set; }
		public bool PassableTroughVertical { get; set; }
		public bool PassableRight2Top { get; set; }
		public bool PassableRight2Bottom { get; set; }
		public bool PassableLeft2Top { get; set; }
		public bool PassableLeft2Bottom { get; set; }
        #endregion

        #region Параметры проходимости по цветам
        
        public bool PassableThoughHorizontalGreen { get; set; }
        public bool PassableThoughHorizontalBlue { get; set; }
        public bool PassableTroughVerticalGreen { get; set; }
        public bool PassableTroughVerticalBlue { get; set; }
        public bool PassableRight2TopGreen { get; set; }
        public bool PassableRight2TopBlue { get; set; }
        public bool PassableRight2BottomGreen { get; set; }
        public bool PassableRight2BottomBlue { get; set; }
        public bool PassableLeft2TopGreen { get; set; }
        public bool PassableLeft2TopBlue { get; set; }
        public bool PassableLeft2BottomGreen { get; set; }
        public bool PassableLeft2BottomBlue { get; set; }

        #endregion
        */
        #region Connections
        
        public ConnectionType ConnectionLeft { get; set; }
        public ConnectionType ConnectionRight { get; set; }
        public ConnectionType ConnectionTop { get; set; }
        public ConnectionType ConnectionBottom { get; set; }

        #endregion

        #region Passability
        
        public ConnectionType PassabilityVertical { get; set; }
        public ConnectionType PassabilityHorizontal { get; set; }
        public ConnectionType PassabilityLeft2Top { get; set; }
        public ConnectionType PassabilityRight2Top { get; set; }
        public ConnectionType PassabilityLeft2Bottom { get; set; }
        public ConnectionType PassabilityRight2Bottom { get; set; }
        
        #endregion

        /*
        #region Parameters of connection to stairs

        //private bool _leftConnection, _rightConnection, _topConnection, _bottomConnection;

        public bool ConnectedLeft { get; set; }
        public bool ConnectedRight { get; set; }
        public bool ConnectedTop { get; set; }
        public bool ConnectedBottom { get; set; }

        public bool ConnectedLeftBlue { get; set; }
        public bool ConnectedLeftGreen { get; set; }
        public bool ConnectedRightBlue { get; set; }
        public bool ConnectedRightGreen { get; set; }
        public bool ConnectedTopBlue { get; set; }
        public bool ConnectedTopGreen { get; set; }
        public bool ConnectedBottomBlue { get; set; }
        public bool ConnectedBottomGreen { get; set; }

        #endregion
        */
        #region Neighbours

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

        #endregion

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
            var temp = PassabilityLeft2Top;
            PassabilityLeft2Top = PassabilityRight2Bottom;
            PassabilityRight2Bottom = temp;

            temp = PassabilityLeft2Bottom;
            PassabilityLeft2Bottom = PassabilityRight2Top;
            PassabilityRight2Top = temp;
        }
	}
}
