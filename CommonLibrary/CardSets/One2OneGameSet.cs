using CommonLibrary.CardsClasses;
using CommonLibrary.Enumerations;
using System.Collections.Generic;

namespace CommonLibrary.CardSets
{
    public class One2OneGameSet : IGameSet
    {
        public List<CardSet> CardSets => new List<CardSet>
        {
            new CardSet(CardType.RouteCard, ImagePaths.Cross, RouteType.Cross),
            new CardSet(CardType.RouteCard, ImagePaths.Bridge, RouteType.Bridge),
            new CardSet(CardType.RouteCard, ImagePaths.ShortLine, RouteType.ShortLine),
            new CardSet(CardType.RouteCard, ImagePaths.LongLine, RouteType.LongLine),
            new CardSet(CardType.RouteCard, ImagePaths.ThreeLinesShort, RouteType.ThreeLinesShort),
            new CardSet(CardType.RouteCard, ImagePaths.ThreeLinesLong, RouteType.ThreeLinesLong),
            new CardSet(CardType.RouteCard, ImagePaths.LeftAngle, RouteType.LeftAngle),
            new CardSet(CardType.RouteCard, ImagePaths.RightAngle, RouteType.RightAngle),
            new CardSet(CardType.RouteCard, ImagePaths.LeftAngleDiagonals, RouteType.LeftAngleDiagonals),
            new CardSet(CardType.RouteCard, ImagePaths.RightAngleDiagonals, RouteType.RightAngleDiagonals),
            new CardSet(CardType.RouteCard, ImagePaths.ThreeLinesLongWithDeadEnd, RouteType.ThreeDeadEndsLongWithDeadEnd),
            new CardSet(CardType.RouteCard, ImagePaths.ThreeLinesShortWithDeadEnd, RouteType.ThreeLinesShortWithDeadEnd),
            new CardSet(CardType.RouteCard, ImagePaths.ShortLineWithDeadEnd, RouteType.ShortLineWithDeadEnd),
            new CardSet(CardType.RouteCard, ImagePaths.LongWithDeadEnd, RouteType.LongWithDeadEnd),
            new CardSet(CardType.RouteCard, ImagePaths.RightAngleWithLeftDeadEnd, RouteType.RightAngleWithLeftDeadEnd),
            new CardSet(CardType.RouteCard, ImagePaths.RightAngleWithBottomDeadEnd, RouteType.RightAngleWithBottomDeadEnd),
            new CardSet(CardType.RouteCard, ImagePaths.LeftAngleWithRightDeadEnd, RouteType.LeftAngleWithRightDeadEnd),
            new CardSet(CardType.RouteCard, ImagePaths.LeftAngleWithBottomDeadEnd, RouteType.LeftAngleWithBottomDeadEnd),

            new CardSet(CardType.ActionCard, ImagePaths.LampBreak, 2),
            new CardSet(CardType.ActionCard, ImagePaths.PickBreak, 2),
            new CardSet(CardType.ActionCard, ImagePaths.TrolleyBreak, 2),
            new CardSet(CardType.ActionCard, ImagePaths.LampFix, 1),
            new CardSet(CardType.ActionCard, ImagePaths.PickFix, 1),
            new CardSet(CardType.ActionCard, ImagePaths.TrolleyFix, 1),
            new CardSet(CardType.ActionCard, ImagePaths.TrolleyLampFix, 1),
            new CardSet(CardType.ActionCard, ImagePaths.LampPickFix, 1),
            new CardSet(CardType.ActionCard, ImagePaths.TrolleyPickFix, 1),
            new CardSet(CardType.ActionCard, ImagePaths.Map, 2),
            new CardSet(CardType.ActionCard, ImagePaths.Bang, 2),

            new CardSet(CardType.GoldCard, ImagePaths.Cross_0),
            new CardSet(CardType.GoldCard, ImagePaths.FourDeadEnds_0),
            new CardSet(CardType.GoldCard, ImagePaths.ThreeDeadEndsLong_0),
            new CardSet(CardType.GoldCard, ImagePaths.ThreeDeadEndsShort_0),
            new CardSet(CardType.GoldCard, ImagePaths.LeftAngle_1),
            new CardSet(CardType.GoldCard, ImagePaths.LeftAngle_2),
            new CardSet(CardType.GoldCard, ImagePaths.RightAngle_1),
            new CardSet(CardType.GoldCard, ImagePaths.RightAngle_2),
            new CardSet(CardType.GoldCard, ImagePaths.TwoDeadEndsLeft_1),
            new CardSet(CardType.GoldCard, ImagePaths.TwoDeadEndsRight_3),
            new CardSet(CardType.GoldCard, ImagePaths.LongLineWithTwoDeadEnds_1),
            new CardSet(CardType.GoldCard, ImagePaths.ShortLineWithTwoDeadEnds_2),
            new CardSet(CardType.GoldCard, ImagePaths.ThreeLinesLong_1),
            new CardSet(CardType.GoldCard, ImagePaths.ThreeLinesLong_2),
            new CardSet(CardType.GoldCard, ImagePaths.ThreeLinesLong_3),
            new CardSet(CardType.GoldCard, ImagePaths.ThreeLinesShort_1),
            new CardSet(CardType.GoldCard, ImagePaths.ThreeLinesShort_2),
            new CardSet(CardType.GoldCard, ImagePaths.ThreeLinesShort_3),
        };

        public List<Coordinates> GoldCardCoordinates => new List<Coordinates>
        {
            new Coordinates(6, 1),
            new Coordinates(6, 3),
            new Coordinates(6, 5),
            new Coordinates(8, 2),
            new Coordinates(8, 4),
            new Coordinates(10, 3),
        };

        public List<RouteCard> StartCards => new List<RouteCard>
        {
            new RouteCard(100, RouteType.StartBlue, ImagePaths.StartBlue) {Coordinates = new Coordinates(0, 2)},
            new RouteCard(200, RouteType.StartGreen, ImagePaths.StartGreen) {Coordinates = new Coordinates(0, 4)}
        };
    }
}
