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

            PassableLeft2BottomBlue = cardOrientation.PassableLeft2BottomBlue;
            PassableLeft2BottomGreen = cardOrientation.PassableLeft2BottomGreen;
            PassableLeft2TopBlue = cardOrientation.PassableLeft2TopBlue;
            PassableLeft2TopGreen = cardOrientation.PassableLeft2TopGreen;
            PassableRight2BottomGreen = cardOrientation.PassableRight2BottomGreen;
            PassableRight2BottomBlue = cardOrientation.PassableRight2BottomBlue;
            PassableRight2TopBlue = cardOrientation.PassableRight2TopBlue;
            PassableRight2TopGreen = cardOrientation.PassableRight2TopGreen;
            PassableTroughVerticalBlue = cardOrientation.PassableTroughVerticalBlue;
            PassableTroughVerticalGreen = cardOrientation.PassableTroughVerticalGreen;
            PassableThoughHorizontalBlue = cardOrientation.PassableThoughHorizontalBlue;
            PassableThoughHorizontalGreen = cardOrientation.PassableThoughHorizontalGreen;
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

            temp = PassableLeft2TopGreen;
            PassableLeft2TopGreen = PassableRight2BottomGreen;
            PassableRight2BottomGreen = temp;

            temp = PassableLeft2BottomGreen;
            PassableLeft2BottomGreen = PassableRight2TopGreen;
            PassableRight2TopGreen = temp;

            temp = PassableLeft2TopBlue;
            PassableLeft2TopBlue = PassableRight2BottomBlue;
            PassableRight2BottomBlue = temp;

            temp = PassableLeft2BottomBlue;
            PassableLeft2BottomBlue = PassableRight2TopBlue;
            PassableRight2TopBlue = temp;
        }
	}
}
