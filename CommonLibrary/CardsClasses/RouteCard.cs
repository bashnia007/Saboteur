using CommonLibrary.Enumerations;
using System;
using System.Linq;
using CommonLibrary.Features;

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
                ChangeGoldConnections();
            }
        }

        #region Constructors

        public RouteCard(int id, string imagePath) : base(id, imagePath)
        {

        }

        public RouteCard(int id, RouteType routeType, string imagePath, int goldCount = 0) : base(id, imagePath)
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

            GoldConnections = cardOrientation.GoldConnections;
            Gold = goldCount;
            IsTaken = false;
        }

        public RouteCard(int id) : base(id) { }

	    public RouteCard(int x, int y) : base(x, y)
	    {

        }

        #endregion

        public int Gold { get; set; }
        public bool IsTaken { get; set; }
        public bool IsTroll { get; set; }

        #region Параметры возможности присоединения к карточке

        public bool JoiningTop { get; set; }
		public bool JoiningBottom { get; set; }
		public bool JoiningRight { get; set; }
		public bool JoiningLeft { get; set; }

		#endregion

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

        public GoldConnections GoldConnections = new GoldConnections();

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

        private void ChangeGoldConnections()
        {
            var temp = GoldConnections.FromTop;
            GoldConnections.FromTop = GoldConnections.FromBottom;
            GoldConnections.FromBottom = temp;

            temp = GoldConnections.FromLeft;
            GoldConnections.FromLeft = GoldConnections.FromRight;
            GoldConnections.FromRight = temp;
        }
	}
}
