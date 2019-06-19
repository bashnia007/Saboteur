using CommonLibrary.CardsClasses;
using CommonLibrary.Enumerations;
using System.Collections.Generic;

namespace CommonLibrary.CardSets
{
    public class One2OneGameSet : IGameSet
    {
        public List<CardSet> CardSets => new List<CardSet>
        {
            new CardSet(CardType.RouteCard, ImagePaths.Cross, 3),
            new CardSet(CardType.RouteCard, ImagePaths.Bridge, 2),
            new CardSet(CardType.RouteCard, ImagePaths.ShortLine, 4),
            new CardSet(CardType.RouteCard, ImagePaths.LongLine, 3),
            new CardSet(CardType.RouteCard, ImagePaths.ThreeLinesShort, 3),
            new CardSet(CardType.RouteCard, ImagePaths.ThreeLinesLong, 3),
            new CardSet(CardType.RouteCard, ImagePaths.LeftAngle, 3),
            new CardSet(CardType.RouteCard, ImagePaths.RightAngle, 3),
            new CardSet(CardType.RouteCard, ImagePaths.LeftAngleDiagonals, 1),
            new CardSet(CardType.RouteCard, ImagePaths.RightAngleDiagonals, 1),
            new CardSet(CardType.RouteCard, ImagePaths.ThreeLinesLongWithDeadEnd, 1),
            new CardSet(CardType.RouteCard, ImagePaths.ThreeLinesShortWithDeadEnd, 1),
            new CardSet(CardType.RouteCard, ImagePaths.ShortLineWithDeadEnd, 1),
            new CardSet(CardType.RouteCard, ImagePaths.LongWithDeadEnd, 1),
            new CardSet(CardType.RouteCard, ImagePaths.RightAngleWithLeftDeadEnd, 1),
            new CardSet(CardType.RouteCard, ImagePaths.RightAngleWithBottomDeadEnd, 1),
            new CardSet(CardType.RouteCard, ImagePaths.LeftAngleWithRightDeadEnd, 1),
            new CardSet(CardType.RouteCard, ImagePaths.LeftAngleWithBottomDeadEnd, 1),

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
            new RouteCard(100, ImagePaths.StartBlue) {Coordinates = new Coordinates(0, 2)},
            new RouteCard(200, ImagePaths.StartGreen) {Coordinates = new Coordinates(0, 4)}
        };
    }
}
