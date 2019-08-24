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
            TopJoining = cardOrientation.TopJoining;
            BottomJoining = cardOrientation.BottomJoining;
            LeftJoining = cardOrientation.LeftJoining;
            RightJoining = cardOrientation.RightJoining;

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
        public bool TopJoining { get; set; }
		public bool BottomJoining { get; set; }
		public bool RightJoining { get; set; }
		public bool LeftJoining { get; set; }
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

        public bool LeftConnected { get; set; }
        public bool RightConnected { get; set; }
        public bool TopConnected { get; set; }
        public bool BottomConnected { get; set; }
        
        #endregion

        private void ChangeOrientation()
        {
            bool temp = TopJoining;
            TopJoining = BottomJoining;
            BottomJoining = temp;

            temp = LeftJoining;
            LeftJoining = RightJoining;
            RightJoining = temp;
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
