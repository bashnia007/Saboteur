using CommonLibrary.Enumerations;

namespace CommonLibrary
{
    public class RouteCardOrientation
    {
        public RouteCardOrientation(RouteType routeType)
        {
            SetOrientation(routeType);
        }

        public bool TopJoining { get; private set; }
        public bool BottomJoining { get; private set; }
        public bool RightJoining { get; private set; }
        public bool LeftJoining { get; private set; }

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
                case RouteType.ThreeDeadEndsLongWithDeadEnd:
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
    }
}
