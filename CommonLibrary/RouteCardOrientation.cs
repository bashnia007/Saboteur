using CommonLibrary.Enumerations;

namespace CommonLibrary
{
    public class RouteCardOrientation
    {
        public RouteCardOrientation(RouteType routeType)
        {
            SetOrientation(routeType);
            SetPassable(routeType);
        }

        public bool TopJoining { get; private set; }
        public bool BottomJoining { get; private set; }
        public bool RightJoining { get; private set; }
        public bool LeftJoining { get; private set; }

        public bool PassableThoughHorizontal { get; set; }
        public bool PassableTroughVertical { get; set; }
        public bool PassableBlue { get; set; }
        public bool PassableGreen { get; set; }
        public bool PassableRight2Top { get; set; }
        public bool PassableRight2Bottom { get; set; }
        public bool PassableLeft2Top { get; set; }
        public bool PassableLeft2Bottom { get; set; }

        private void SetOrientation(RouteType routeType)
        {
            switch (routeType)
            {
                case RouteType.Bridge:
                case RouteType.Cross:
                case RouteType.FourDeadEnds:
                case RouteType.LeftAngleDiagonals:
                case RouteType.LongLineWithTwoDeadEnds:
                case RouteType.RightAngleDiagonals:
                case RouteType.ShortLineWithTwoDeadEnds:
                case RouteType.StartBlue:
                case RouteType.StartGreen:
                case RouteType.ThreeLinesLongWithDeadEnd:
                case RouteType.ThreeLinesShortWithDeadEnd:
                    TopJoining = true;
                    BottomJoining = true;
                    LeftJoining = true;
                    RightJoining = true;
                    break;

                case RouteType.LeftAngle:
                case RouteType.TwoDeadLinesLeft:
                    TopJoining = true;
                    BottomJoining = false;
                    LeftJoining = true;
                    RightJoining = false;
                    break;

                case RouteType.LeftAngleWithBottomDeadEnd:
                case RouteType.LongWithDeadEnd:
                case RouteType.ThreeDeadEndsLong:
                case RouteType.ThreeLinesLong:
                    TopJoining = true;
                    BottomJoining = true;
                    LeftJoining = true;
                    RightJoining = false;
                    break;

                case RouteType.LeftAngleWithRightDeadEnd:
                case RouteType.RightAngleWithLeftDeadEnd:
                case RouteType.ThreeDeadEndsShort:
                case RouteType.ThreeLinesShort:
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

        private void SetPassable(RouteType routeType)
        {
            // by default all passable variables set to false
            PassableThoughHorizontal = false;
            PassableTroughVertical = true;
            PassableRight2Top = false;
            PassableRight2Bottom = false;
            PassableLeft2Top = false;
            PassableLeft2Bottom = false;

            switch (routeType)
            {
                case RouteType.Bridge:
                    PassableThoughHorizontal = true;
                    PassableTroughVertical = true;
                    break;

                case RouteType.Cross:
                case RouteType.StartBlue:
                case RouteType.StartGreen:
                    PassableThoughHorizontal = true;
                    PassableTroughVertical = true;
                    PassableRight2Top = true;
                    PassableRight2Bottom = true;
                    PassableLeft2Top = true;
                    PassableLeft2Bottom = true;
                    break;

                case RouteType.FourDeadEnds:
                case RouteType.ThreeDeadEndsLong:
                case RouteType.ThreeDeadEndsShort:
                case RouteType.TwoDeadLinesLeft:
                case RouteType.TwoDeadLinesRight:
                    break;

                case RouteType.LeftAngle:
                case RouteType.LeftAngleWithBottomDeadEnd:
                case RouteType.LeftAngleWithRightDeadEnd:
                    PassableLeft2Top = true;
                    break;

                case RouteType.LeftAngleDiagonals:
                    PassableRight2Bottom = true;
                    PassableLeft2Top = true;
                    break;

                case RouteType.LongLine:
                case RouteType.LongLineWithTwoDeadEnds:
                case RouteType.LongWithDeadEnd:
                    PassableThoughHorizontal = false;
                    PassableTroughVertical = true;
                    break;

                case RouteType.RightAngle:
                case RouteType.RightAngleWithBottomDeadEnd:
                case RouteType.RightAngleWithLeftDeadEnd:
                    PassableRight2Top = true;
                    break;

                case RouteType.RightAngleDiagonals:
                    PassableRight2Top = true;
                    PassableLeft2Bottom = true;
                    break;

                case RouteType.ShortLine:
                case RouteType.ShortLineWithDeadEnd:
                case RouteType.ShortLineWithTwoDeadEnds:
                    PassableThoughHorizontal = true;
                    break;

                case RouteType.ThreeLinesLong:
                    PassableTroughVertical = true;
                    PassableLeft2Bottom = true;
                    PassableLeft2Top = true;
                    break;

                case RouteType.ThreeLinesLongWithDeadEnd:
                    PassableTroughVertical = true;
                    PassableRight2Top = true;
                    PassableRight2Bottom = true;
                    break;

                case RouteType.ThreeLinesShort:
                case RouteType.ThreeLinesShortWithDeadEnd:
                    PassableThoughHorizontal = true;
                    PassableLeft2Top = true;
                    PassableRight2Top = true;
                    break;
            }
        }
    }
}
