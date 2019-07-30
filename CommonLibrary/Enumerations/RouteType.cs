using System;

namespace CommonLibrary.Enumerations
{
    [Serializable]
    public enum RouteType
	{
        Bridge,
		Cross,
        FourDeadEnds,
        LeftAngle,
		LeftAngleDiagonals,
        LeftAngleWithBottomDeadEnd,
        LeftAngleWithRightDeadEnd,
        LongLine,
        LongLineWithTwoDeadEnds,
        LongWithDeadEnd,
        RightAngle,
        RightAngleDiagonals,
        RightAngleWithBottomDeadEnd,
        RightAngleWithLeftDeadEnd,
	    ShortLine,
        ShortLineWithDeadEnd,
        ShortLineWithTwoDeadEnds,
        StartBlue,
        StartGreen,
        ThreeDeadEndsLong,
        ThreeDeadEndsShort,
        ThreeDeadEndsLongWithDeadEnd,
        ThreeLinesShort,
        ThreeLinesLong,
        ThreeLinesShortWithDeadEnd,
        TwoDeadLinesLeft,
        TwoDeadLinesRight,
	}
}
