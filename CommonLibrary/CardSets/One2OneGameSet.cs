using CommonLibrary.CardsClasses;
using CommonLibrary.Enumerations;
using System.Collections.Generic;

namespace CommonLibrary.CardSets
{
    public class One2OneGameSet : IGameSet
    {
        public List<CardSet> CardSets => new List<CardSet>
        {
            new CardSet(CardType.RouteCard, ImagePaths.CrossTroll, RouteType.CrossTroll),
            new CardSet(CardType.RouteCard, ImagePaths.CrossBlue, RouteType.CrossBlue),
            new CardSet(CardType.RouteCard, ImagePaths.CrossGreen, RouteType.CrossGreen),
            new CardSet(CardType.RouteCard, ImagePaths.Bridge, RouteType.Bridge),
            new CardSet(CardType.RouteCard, ImagePaths.BridgeGold, RouteType.BridgeGold),
            new CardSet(CardType.RouteCard, ImagePaths.ShortLine, RouteType.ShortLine, 4),
            new CardSet(CardType.RouteCard, ImagePaths.LongLine, RouteType.LongLine, 3),
            new CardSet(CardType.RouteCard, ImagePaths.ThreeLinesShortBlue, RouteType.ThreeLinesShortBlue),
            new CardSet(CardType.RouteCard, ImagePaths.ThreeLinesShortGreen, RouteType.ThreeLinesShortGreen),
            new CardSet(CardType.RouteCard, ImagePaths.ThreeLinesShortTroll, RouteType.ThreeLinesShortTroll),
            new CardSet(CardType.RouteCard, ImagePaths.ThreeLinesLongBlue, RouteType.ThreeLinesLongBlue),
            new CardSet(CardType.RouteCard, ImagePaths.ThreeLinesLongBlueGold, RouteType.ThreeLinesLongBlueGold),
            new CardSet(CardType.RouteCard, ImagePaths.ThreeLinesLongGreen, RouteType.ThreeLinesLongGreen),
            new CardSet(CardType.RouteCard, ImagePaths.ThreeLinesLongTroll, RouteType.ThreeLinesLongTroll),
            new CardSet(CardType.RouteCard, ImagePaths.LeftAngle, RouteType.LeftAngle, 2),
            new CardSet(CardType.RouteCard, ImagePaths.LeftAngleWithBlueStairs, RouteType.LeftAngleWithStairs),
            new CardSet(CardType.RouteCard, ImagePaths.RightAngle, RouteType.RightAngle, 2),
            new CardSet(CardType.RouteCard, ImagePaths.RightAngleWithGreenStairs, RouteType.RightAngleWithStairs),
            new CardSet(CardType.RouteCard, ImagePaths.LeftAngleDiagonalsGold, RouteType.LeftAngleDiagonalsGold),
            new CardSet(CardType.RouteCard, ImagePaths.RightAngleDiagonals, RouteType.RightAngleDiagonals),
            new CardSet(CardType.RouteCard, ImagePaths.ThreeLinesLongWithDeadEndGold, RouteType.ThreeLinesLongWithDeadEndGold),
            new CardSet(CardType.RouteCard, ImagePaths.ThreeLinesShortWithDeadEndGold, RouteType.ThreeLinesShortWithDeadEndGold),
            new CardSet(CardType.RouteCard, ImagePaths.ShortLineWithDeadEndGold, RouteType.ShortLineWithDeadEndGold),
            new CardSet(CardType.RouteCard, ImagePaths.LongWithDeadEnd, RouteType.LongLineWithDeadEnd),
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
            new CardSet(CardType.ActionCard, ImagePaths.Map, ActionType.Explore, 2),
            new CardSet(CardType.ActionCard, ImagePaths.Bang, ActionType.DestroyConnection, 2),

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
            new StartCard(100, RouteType.StartBlue, ImagePaths.StartBlue)
            {
                Coordinates = new Coordinates(0, 2),
                ConnectionBottom = ConnectionType.Blue,
                ConnectionLeft = ConnectionType.Blue,
                ConnectionRight = ConnectionType.Blue,
                ConnectionTop = ConnectionType.Blue,
                Role = RoleType.Blue
            },
            new StartCard(200, RouteType.StartGreen, ImagePaths.StartGreen)
            {
                Coordinates = new Coordinates(0, 4),
                ConnectionBottom = ConnectionType.Green,
                ConnectionLeft = ConnectionType.Green,
                ConnectionRight = ConnectionType.Green,
                ConnectionTop = ConnectionType.Green,
                Role = RoleType.Green
            }
        };
    }
}
