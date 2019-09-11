using CommonLibrary.Enumerations;

namespace CommonLibrary
{
    public class RouteCardOrientation
    {
        public RouteCardOrientation(RouteType routeType)
        {
            SetInitialColorOrientation(routeType);
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

        private void SetOrientation(RouteType routeType)
        {
            switch (routeType)
            {
                case RouteType.Bridge:
                case RouteType.BridgeGold:
                case RouteType.Cross:
                case RouteType.CrossBlue:
                case RouteType.CrossGreen:
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
                case RouteType.LongWithDeadEnd:
                case RouteType.ThreeDeadEndsLong:
                case RouteType.ThreeLinesLong:
                case RouteType.ThreeLinesLongBlue:
                case RouteType.ThreeLinesLongGreen:
                case RouteType.ThreeLinesLongBlueGold:
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

        private void SetPassable(RouteType routeType)
        {
            // by default all passable variables set to false
            PassableThoughHorizontal = false;
            PassableTroughVertical = false;
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
                case RouteType.LeftAngleWithStairs:
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
                    PassableTroughVertical = true;
                    break;

                case RouteType.RightAngle:
                case RouteType.RightAngleWithStairs:
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

        private void SetInitialColorOrientation(RouteType routeType)
        {
            switch (routeType)
            {
                case RouteType.CrossBlue:
                    PassableTroughVerticalBlue = true;
                    PassableRight2TopBlue = true;
                    PassableLeft2TopBlue = true;
                    break;
                case RouteType.CrossGreen:
                    PassableThoughHorizontalGreen = true;
                    PassableRight2TopGreen = true;
                    PassableRight2BottomGreen = true;
                    break;
                case RouteType.ThreeLinesShortGreen:
                    PassableRight2BottomGreen = true;
                    PassableLeft2BottomGreen = true;
                    break;
                case RouteType.ThreeLinesShortBlue:
                    PassableThoughHorizontalBlue = true;
                    PassableLeft2BottomBlue = true;
                    break;
                case RouteType.ThreeLinesLongBlue:
                    PassableTroughVerticalBlue = true;
                    PassableRight2BottomBlue = true;
                    break;
                case RouteType.ThreeLinesLongGreen:
                    PassableTroughVerticalGreen = true;
                    PassableRight2TopBlue = true;
                    break;
                case RouteType.ThreeLinesLongBlueGold:
                    PassableRight2BottomBlue = true;
                    PassableRight2TopBlue = true;
                    break;
                default:
                    PassableThoughHorizontalGreen = true;
                    PassableThoughHorizontalBlue = true;
                    PassableTroughVerticalGreen = true;
                    PassableTroughVerticalBlue = true;
                    PassableRight2TopGreen = true;
                    PassableRight2TopBlue = true;
                    PassableRight2BottomGreen = true;
                    PassableRight2BottomBlue = true;
                    PassableLeft2TopGreen = true;
                    PassableLeft2TopBlue = true;
                    PassableLeft2BottomGreen = true;
                    PassableLeft2BottomBlue = true;
                    break;
            }
        }
    }
}
