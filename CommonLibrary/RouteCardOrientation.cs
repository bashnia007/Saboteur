using CommonLibrary.Enumerations;
using CommonLibrary.Features;

namespace CommonLibrary
{
    public class RouteCardOrientation
    {
        public RouteCardOrientation(RouteType routeType)
        {
            SetPassability(routeType);
            SetOrientation(routeType);
            SetGoldConnections(routeType);
        }
        
        public bool TopJoining { get; private set; }
        public bool BottomJoining { get; private set; }
        public bool RightJoining { get; private set; }
        public bool LeftJoining { get; private set; }

        #region Connections to stairs

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

        public GoldConnections GoldConnections { get; set; }

        private void SetPassability(RouteType routeType)
        {
            PassabilityVertical = ConnectionType.None;
            PassabilityHorizontal = ConnectionType.None;
            PassabilityLeft2Top = ConnectionType.None;
            PassabilityRight2Top = ConnectionType.None;
            PassabilityLeft2Bottom = ConnectionType.None;
            PassabilityRight2Bottom = ConnectionType.None;

            switch (routeType)
            {
                case RouteType.Cross:
                case RouteType.CrossTroll:
                case RouteType.StartGreen:
                case RouteType.StartBlue:
                    PassabilityVertical = ConnectionType.Both;
                    PassabilityHorizontal = ConnectionType.Both;
                    PassabilityLeft2Top = ConnectionType.Both;
                    PassabilityRight2Top = ConnectionType.Both;
                    PassabilityLeft2Bottom = ConnectionType.Both;
                    PassabilityRight2Bottom = ConnectionType.Both;
                    break;
                case RouteType.CrossBlue:
                    PassabilityVertical = ConnectionType.Blue;
                    PassabilityHorizontal = ConnectionType.Both;
                    PassabilityLeft2Top = ConnectionType.Both;
                    PassabilityRight2Top = ConnectionType.Both;
                    PassabilityLeft2Bottom = ConnectionType.Blue;
                    PassabilityRight2Bottom = ConnectionType.Blue;
                    break;
                case RouteType.CrossGreen:
                    PassabilityVertical = ConnectionType.Both;
                    PassabilityHorizontal = ConnectionType.Green;
                    PassabilityLeft2Top = ConnectionType.Green;
                    PassabilityRight2Top = ConnectionType.Both;
                    PassabilityLeft2Bottom = ConnectionType.Green;
                    PassabilityRight2Bottom = ConnectionType.Both;
                    break;
                case RouteType.Bridge:
                case RouteType.BridgeGold:
                    PassabilityVertical = ConnectionType.Both;
                    PassabilityHorizontal = ConnectionType.Both;
                    break;
                case RouteType.LongLine:
                case RouteType.LongLineWithDeadEnd:
                case RouteType.LongLineWithTwoDeadEndsGold2:
                    PassabilityVertical = ConnectionType.Both;
                    break;
                case RouteType.ShortLine:
                case RouteType.ShortLineWithDeadEndGold:
                case RouteType.ShortLineWithTwoDeadEndsGold2:
                    PassabilityHorizontal = ConnectionType.Both;
                    break;
                case RouteType.LeftAngle:
                case RouteType.LeftAngleGold2:
                case RouteType.LeftAngleWithBottomDeadEnd:
                case RouteType.LeftAngleWithRightDeadEnd:
                case RouteType.LeftAngleWithStairs:
                    PassabilityLeft2Top = ConnectionType.Both;
                    break;
                case RouteType.RightAngle:
                case RouteType.RightAngleGold2:
                case RouteType.RightAngleWithBottomDeadEnd:
                case RouteType.RightAngleWithLeftDeadEnd:
                case RouteType.RightAngleWithStairs:
                    PassabilityRight2Top = ConnectionType.Both;
                    break;
                case RouteType.ThreeLinesShortTroll:
                case RouteType.ThreeLinesShortWithDeadEndGold:
                case RouteType.ThreeLinesShort:
                    PassabilityHorizontal = ConnectionType.Both;
                    PassabilityRight2Top = ConnectionType.Both;
                    PassabilityLeft2Top = ConnectionType.Both;
                    break;
                case RouteType.ThreeLinesLong:
                case RouteType.ThreeLinesLongTroll:
                case RouteType.ThreeLinesLongWithDeadEndGold:
                    PassabilityVertical = ConnectionType.Both;
                    PassabilityLeft2Top = ConnectionType.Both;
                    PassabilityLeft2Bottom = ConnectionType.Both;
                    break;
                case RouteType.LeftAngleDiagonalsGold:
                    PassabilityLeft2Top = ConnectionType.Both;
                    PassabilityRight2Bottom = ConnectionType.Both;
                    break;
                case RouteType.RightAngleDiagonals:
                    PassabilityLeft2Bottom = ConnectionType.Both;
                    PassabilityRight2Top = ConnectionType.Both;
                    break;
                case RouteType.ThreeLinesLongBlueGold:
                    PassabilityVertical = ConnectionType.Both;
                    PassabilityLeft2Bottom = ConnectionType.Blue;
                    PassabilityLeft2Top = ConnectionType.Blue;
                    break;
                case RouteType.ThreeLinesLongBlue:
                    PassabilityVertical = ConnectionType.Blue;
                    PassabilityLeft2Bottom = ConnectionType.Both;
                    PassabilityLeft2Top = ConnectionType.Blue;
                    break;
                case RouteType.ThreeLinesLongBlueGold3:
                    PassabilityVertical = ConnectionType.Blue;
                    PassabilityLeft2Bottom = ConnectionType.Both;
                    PassabilityLeft2Top = ConnectionType.Blue;
                    break;
                case RouteType.ThreeLinesLongGreen:
                    PassabilityVertical = ConnectionType.Green;
                    PassabilityLeft2Bottom = ConnectionType.Green;
                    PassabilityLeft2Top = ConnectionType.Both;
                    break;
                case RouteType.ThreeLinesLongGreenGold2:
                    PassabilityVertical = ConnectionType.Green;
                    PassabilityLeft2Bottom = ConnectionType.Green;
                    PassabilityLeft2Top = ConnectionType.Both;
                    break;
                case RouteType.ThreeLinesShortGreen:
                    PassabilityHorizontal = ConnectionType.Both;
                    PassabilityLeft2Top = ConnectionType.Green;
                    PassabilityRight2Top = ConnectionType.Green;
                    break;
                case RouteType.ThreeLinesShortGreenGold:
                    PassabilityHorizontal = ConnectionType.Green;
                    PassabilityLeft2Top = ConnectionType.Both;
                    PassabilityRight2Top = ConnectionType.Green;
                    break;
                case RouteType.ThreeLinesShortGreenGold3:
                    PassabilityHorizontal = ConnectionType.Both;
                    PassabilityLeft2Top = ConnectionType.Green;
                    PassabilityRight2Top = ConnectionType.Green;
                    break;
                case RouteType.ThreeLinesShortBlue:
                    PassabilityHorizontal = ConnectionType.Blue;
                    PassabilityLeft2Top = ConnectionType.Both;
                    PassabilityRight2Top = ConnectionType.Blue;
                    break;
                case RouteType.ThreeLinesShortBlueGold2:
                    PassabilityHorizontal = ConnectionType.Both;
                    PassabilityLeft2Top = ConnectionType.Blue;
                    PassabilityRight2Top = ConnectionType.Blue;
                    break;
                case RouteType.RightAngleGoldBlue:
                    PassabilityRight2Top = ConnectionType.Blue;
                    break;
                case RouteType.LeftAngleGoldGreen:
                    PassabilityLeft2Top = ConnectionType.Green;
                    break;
            }
        }
        
        private void SetOrientation(RouteType routeType)
        {
            switch (routeType)
            {
                case RouteType.Bridge:
                case RouteType.BridgeGold:
                case RouteType.Cross:
                case RouteType.CrossBlue:
                case RouteType.CrossGreen:
                case RouteType.CrossTroll:
                case RouteType.FourDeadEnds:
                case RouteType.LeftAngleDiagonals:
                case RouteType.LeftAngleDiagonalsGold:
                case RouteType.LongLineWithTwoDeadEndsGold2:
                case RouteType.RightAngleDiagonals:
                case RouteType.ShortLineWithTwoDeadEndsGold2:
                case RouteType.StartBlue:
                case RouteType.StartGreen:
                case RouteType.ThreeLinesLongWithDeadEnd:
                case RouteType.ThreeLinesLongWithDeadEndGold:
                case RouteType.ThreeLinesShortWithDeadEnd:
                case RouteType.ThreeLinesShortWithDeadEndGold:
                    TopJoining = true;
                    BottomJoining = true;
                    LeftJoining = true;
                    RightJoining = true;
                    break;

                case RouteType.LeftAngle:
                case RouteType.LeftAngleWithStairs:
                case RouteType.TwoDeadLinesLeft:
                case RouteType.TwoDeadEndsLeftGold:
                case RouteType.LeftAngleGold2:
                case RouteType.LeftAngleGoldGreen:
                    TopJoining = true;
                    BottomJoining = false;
                    LeftJoining = true;
                    RightJoining = false;
                    break;

                case RouteType.LeftAngleWithBottomDeadEnd:
                case RouteType.LongLineWithDeadEnd:
                case RouteType.ThreeDeadEndsLong:
                case RouteType.ThreeLinesLong:
                case RouteType.ThreeLinesLongBlue:
                case RouteType.ThreeLinesLongBlueGold3:
                case RouteType.ThreeLinesLongGreen:
                case RouteType.ThreeLinesLongGreenGold2:
                case RouteType.ThreeLinesLongBlueGold:
                case RouteType.ThreeLinesLongTroll:
                    TopJoining = true;
                    BottomJoining = true;
                    LeftJoining = true;
                    RightJoining = false;
                    break;

                case RouteType.LeftAngleWithRightDeadEnd:
                case RouteType.RightAngleWithLeftDeadEnd:
                case RouteType.ThreeDeadEndsShort:
                case RouteType.ThreeLinesShort:
                case RouteType.ThreeLinesShortBlue:
                case RouteType.ThreeLinesShortGreen:
                case RouteType.ThreeLinesShortTroll:
                case RouteType.ThreeLinesShortGreenGold:
                case RouteType.ThreeLinesShortBlueGold2:
                case RouteType.ThreeLinesShortGreenGold3:
                    TopJoining = true;
                    BottomJoining = false;
                    LeftJoining = true;
                    RightJoining = true;
                    break;

                case RouteType.LongLine:
                    TopJoining = true;
                    BottomJoining = true;
                    LeftJoining = false;
                    RightJoining = false;
                    break;

                case RouteType.RightAngle:
                case RouteType.RightAngleWithStairs:
                case RouteType.RightAngleGoldBlue:
                case RouteType.RightAngleGold2:
                case RouteType.TwoDeadEndsRightGold3:
                    TopJoining = true;
                    BottomJoining = false;
                    LeftJoining = false;
                    RightJoining = true;
                    break;

                case RouteType.RightAngleWithBottomDeadEnd:
                    TopJoining = true;
                    BottomJoining = true;
                    LeftJoining = false;
                    RightJoining = true;
                    break;

                case RouteType.ShortLine:
                    TopJoining = false;
                    BottomJoining = false;
                    LeftJoining = true;
                    RightJoining = true;
                    break;

                case RouteType.ShortLineWithDeadEnd:
                case RouteType.ShortLineWithDeadEndGold:
                    TopJoining = false;
                    BottomJoining = true;
                    LeftJoining = true;
                    RightJoining = true;
                    break;

                case RouteType.TwoDeadLinesRight:
                    TopJoining = false;
                    BottomJoining = true;
                    LeftJoining = true;
                    RightJoining = false;
                    break;
            }
        }

        private void SetGoldConnections(RouteType routeType)
        {
            GoldConnections = new GoldConnections();
            switch (routeType)
            {
                case RouteType.BridgeGold:
                    GoldConnections.FromTop = ConnectionType.Both;
                    GoldConnections.FromBottom = ConnectionType.Both;
                    break;
                case RouteType.LeftAngleDiagonalsGold:
                    GoldConnections.FromRight = ConnectionType.Both;
                    GoldConnections.FromBottom = ConnectionType.Both;
                    break;
                case RouteType.ThreeLinesLongBlueGold:
                    GoldConnections.FromLeft = ConnectionType.Blue;
                    GoldConnections.FromBottom = ConnectionType.Both;
                    GoldConnections.FromTop = ConnectionType.Both;
                    break;
                case RouteType.ThreeLinesLongBlueGold3:
                    GoldConnections.FromLeft = ConnectionType.Both;
                    GoldConnections.FromBottom = ConnectionType.Both;
                    GoldConnections.FromTop = ConnectionType.Blue;
                    break;
                case RouteType.ThreeLinesLongGreenGold2:
                    GoldConnections.FromLeft = ConnectionType.Both;
                    GoldConnections.FromBottom = ConnectionType.Green;
                    GoldConnections.FromTop = ConnectionType.Both;
                    break;
                case RouteType.ThreeLinesShortWithDeadEndGold:
                    GoldConnections.FromBottom = ConnectionType.Both;
                    break;
                case RouteType.ThreeLinesLongWithDeadEndGold:
                    GoldConnections.FromRight = ConnectionType.Both;
                    break;
                case RouteType.ShortLineWithDeadEndGold:
                    GoldConnections.FromBottom = ConnectionType.Both;
                    break;
                case RouteType.ThreeLinesShortGreenGold:
                    GoldConnections.FromLeft = ConnectionType.Both;
                    GoldConnections.FromRight = ConnectionType.Green;
                    GoldConnections.FromTop = ConnectionType.Both;
                    break;
                case RouteType.ThreeLinesShortGreenGold3:
                    GoldConnections.FromLeft = ConnectionType.Both;
                    GoldConnections.FromRight = ConnectionType.Both;
                    GoldConnections.FromTop = ConnectionType.Green;
                    break;
                case RouteType.ThreeLinesShortBlueGold2:
                    GoldConnections.FromLeft = ConnectionType.Both;
                    GoldConnections.FromRight = ConnectionType.Both;
                    GoldConnections.FromTop = ConnectionType.Blue;
                    break;
                case RouteType.RightAngleGoldBlue:
                    GoldConnections.FromTop = ConnectionType.Both;
                    GoldConnections.FromRight = ConnectionType.Blue;
                    break;
                case RouteType.RightAngleGold2:
                    GoldConnections.FromTop = ConnectionType.Both;
                    GoldConnections.FromRight = ConnectionType.Both;
                    break;
                case RouteType.LeftAngleGoldGreen:
                    GoldConnections.FromTop = ConnectionType.Both;
                    GoldConnections.FromLeft = ConnectionType.Green;
                    break;
                case RouteType.LeftAngleGold2:
                    GoldConnections.FromTop = ConnectionType.Both;
                    GoldConnections.FromLeft = ConnectionType.Both;
                    break;
                case RouteType.LongLineWithTwoDeadEndsGold2:
                    GoldConnections.FromTop = ConnectionType.Both;
                    GoldConnections.FromBottom = ConnectionType.Both;
                    break;
                case RouteType.ShortLineWithTwoDeadEndsGold2:
                    GoldConnections.FromLeft = ConnectionType.Both;
                    GoldConnections.FromRight = ConnectionType.Both;
                    break;
                case RouteType.TwoDeadEndsRightGold3:
                    GoldConnections.FromTop = ConnectionType.Both;
                    break;
                case RouteType.TwoDeadEndsLeftGold:
                    GoldConnections.FromLeft = ConnectionType.Both;
                    break;
                default:
                    GoldConnections.FromBottom = ConnectionType.None;
                    GoldConnections.FromLeft = ConnectionType.None;
                    GoldConnections.FromRight = ConnectionType.None;
                    GoldConnections.FromTop = ConnectionType.None;
                    break;
            }
        }
    }
}
