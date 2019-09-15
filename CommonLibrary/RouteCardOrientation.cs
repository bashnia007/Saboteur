using CommonLibrary.Enumerations;

namespace CommonLibrary
{
    public class RouteCardOrientation
    {
        public RouteCardOrientation(RouteType routeType)
        {
            SetPassability(routeType);
            SetOrientation(routeType);
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
                    PassabilityLeft2Top = ConnectionType.Blue;
                    PassabilityRight2Top = ConnectionType.Blue;
                    PassabilityLeft2Bottom = ConnectionType.Both;
                    PassabilityRight2Bottom = ConnectionType.Both;
                    break;
                case RouteType.CrossGreen:
                    PassabilityVertical = ConnectionType.Both;
                    PassabilityHorizontal = ConnectionType.Green;
                    PassabilityLeft2Top = ConnectionType.Both;
                    PassabilityRight2Top = ConnectionType.Green;
                    PassabilityLeft2Bottom = ConnectionType.Both;
                    PassabilityRight2Bottom = ConnectionType.Green;
                    break;
                case RouteType.Bridge:
                case RouteType.BridgeGold:
                    PassabilityVertical = ConnectionType.Both;
                    PassabilityHorizontal = ConnectionType.Both;
                    break;
                case RouteType.LongLine:
                case RouteType.LongLineWithDeadEnd:
                    PassabilityVertical = ConnectionType.Both;
                    break;
                case RouteType.ShortLine:
                case RouteType.ShortLineWithDeadEndGold:
                    PassabilityHorizontal = ConnectionType.Both;
                    break;
                case RouteType.LeftAngle:
                case RouteType.LeftAngleWithBottomDeadEnd:
                case RouteType.LeftAngleWithRightDeadEnd:
                case RouteType.LeftAngleWithStairs:
                    PassabilityLeft2Top = ConnectionType.Both;
                    break;
                case RouteType.RightAngle:
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
                case RouteType.ThreeLinesLongGreen:
                    PassabilityVertical = ConnectionType.Green;
                    PassabilityLeft2Bottom = ConnectionType.Green;
                    PassabilityLeft2Top = ConnectionType.Both;
                    break;
                case RouteType.ThreeLinesShortGreen:
                    PassabilityHorizontal = ConnectionType.Both;
                    PassabilityLeft2Top = ConnectionType.Green;
                    PassabilityRight2Top = ConnectionType.Green;
                    break;
                case RouteType.ThreeLinesShortBlue:
                    PassabilityHorizontal = ConnectionType.Blue;
                    PassabilityLeft2Top = ConnectionType.Both;
                    PassabilityRight2Top = ConnectionType.Blue;
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
                case RouteType.LongLineWithTwoDeadEnds:
                case RouteType.RightAngleDiagonals:
                case RouteType.ShortLineWithTwoDeadEnds:
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
                case RouteType.ThreeLinesLongGreen:
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
    }
}
