using CommonLibrary.CardsClasses;
using CommonLibrary.Enumerations;

namespace CommonLibrary.GameSets
{
    public class DuelGameSetFactory : AbstractGameSetFactory
    {
        public DuelGameSetFactory()
        {
            GameSet = new DuelGameSet();
        }
        
        protected override void PrepareRouteCards()
        {
            GameSet.HandCards.Add(new CardSet(CardType.RouteCard, ImagePaths.CrossTroll, RouteType.CrossTroll, count: 25, isTroll: true));
            GameSet.HandCards.Add(new CardSet(CardType.RouteCard, ImagePaths.CrossBlue, RouteType.CrossBlue, count: 25, hasGates: true));
            GameSet.HandCards.Add(new CardSet(CardType.RouteCard, ImagePaths.CrossGreen, RouteType.CrossGreen, hasGates: true));
            GameSet.HandCards.Add(new CardSet(CardType.RouteCard, ImagePaths.Bridge, RouteType.Bridge));
            GameSet.HandCards.Add(new CardSet(CardType.RouteCard, ImagePaths.BridgeGold, RouteType.BridgeGold, goldCount: 1));
            GameSet.HandCards.Add(new CardSet(CardType.RouteCard, ImagePaths.ShortLine, RouteType.ShortLine, 4));
            GameSet.HandCards.Add(new CardSet(CardType.RouteCard, ImagePaths.LongLine, RouteType.LongLine, 3));
            GameSet.HandCards.Add(new CardSet(CardType.RouteCard, ImagePaths.ThreeLinesShortBlue, RouteType.ThreeLinesShortBlue, hasGates: true));
            GameSet.HandCards.Add(new CardSet(CardType.RouteCard, ImagePaths.ThreeLinesShortGreen, RouteType.ThreeLinesShortGreen, hasGates: true));
            GameSet.HandCards.Add(new CardSet(CardType.RouteCard, ImagePaths.ThreeLinesShortTroll, RouteType.ThreeLinesShortTroll, isTroll: true));
            GameSet.HandCards.Add(new CardSet(CardType.RouteCard, ImagePaths.ThreeLinesLongBlue, RouteType.ThreeLinesLongBlue, hasGates: true));
            GameSet.HandCards.Add(new CardSet(CardType.RouteCard, ImagePaths.ThreeLinesLongGreen, RouteType.ThreeLinesLongGreen, hasGates: true));
            GameSet.HandCards.Add(new CardSet(CardType.RouteCard, ImagePaths.ThreeLinesLongTroll, RouteType.ThreeLinesLongTroll, isTroll: true));
            GameSet.HandCards.Add(new CardSet(CardType.RouteCard, ImagePaths.LeftAngle, RouteType.LeftAngle, 2));
            GameSet.HandCards.Add(new CardSet(CardType.RouteCard, ImagePaths.RightAngle, RouteType.RightAngle, 2));
            GameSet.HandCards.Add(new CardSet(CardType.StairsCard, ImagePaths.LeftAngleWithBlueStairs, RouteType.LeftAngleWithStairs));
            GameSet.HandCards.Add(new CardSet(CardType.StairsCard, ImagePaths.RightAngleWithGreenStairs, RouteType.RightAngleWithStairs));
            GameSet.HandCards.Add(new CardSet(CardType.RouteCard, ImagePaths.LeftAngleDiagonalsGold, RouteType.LeftAngleDiagonalsGold, goldCount: 1));
            GameSet.HandCards.Add(new CardSet(CardType.RouteCard, ImagePaths.RightAngleDiagonals, RouteType.RightAngleDiagonals));
            GameSet.HandCards.Add(new CardSet(CardType.RouteCard, ImagePaths.ThreeLinesLongWithDeadEndGold, RouteType.ThreeLinesLongWithDeadEndGold, goldCount: 1));
            GameSet.HandCards.Add(new CardSet(CardType.RouteCard, ImagePaths.ThreeLinesShortWithDeadEndGold, RouteType.ThreeLinesShortWithDeadEndGold, goldCount: 1));
            GameSet.HandCards.Add(new CardSet(CardType.RouteCard, ImagePaths.ShortLineWithDeadEndGold, RouteType.ShortLineWithDeadEndGold, goldCount: 1));
            GameSet.HandCards.Add(new CardSet(CardType.RouteCard, ImagePaths.LongWithDeadEnd, RouteType.LongLineWithDeadEnd));
            GameSet.HandCards.Add(new CardSet(CardType.RouteCard, ImagePaths.RightAngleWithLeftDeadEnd, RouteType.RightAngleWithLeftDeadEnd));
            GameSet.HandCards.Add(new CardSet(CardType.RouteCard, ImagePaths.RightAngleWithBottomDeadEnd, RouteType.RightAngleWithBottomDeadEnd));
            GameSet.HandCards.Add(new CardSet(CardType.RouteCard, ImagePaths.LeftAngleWithRightDeadEnd, RouteType.LeftAngleWithRightDeadEnd));
            GameSet.HandCards.Add(new CardSet(CardType.RouteCard, ImagePaths.LeftAngleWithBottomDeadEnd, RouteType.LeftAngleWithBottomDeadEnd));
        }

        protected override void PrepareActionCards()
        {
            GameSet.HandCards.Add(new CardSet(CardType.ActionCard, ImagePaths.LampBreak, 2));
            GameSet.HandCards.Add(new CardSet(CardType.ActionCard, ImagePaths.PickBreak, 2));
            GameSet.HandCards.Add(new CardSet(CardType.ActionCard, ImagePaths.TrolleyBreak, 2));
            GameSet.HandCards.Add(new CardSet(CardType.ActionCard, ImagePaths.LampFix, 1));
            GameSet.HandCards.Add(new CardSet(CardType.ActionCard, ImagePaths.PickFix, 1));
            GameSet.HandCards.Add(new CardSet(CardType.ActionCard, ImagePaths.TrolleyFix, 1));
            GameSet.HandCards.Add(new CardSet(CardType.ActionCard, ImagePaths.TrolleyLampFix, 1));
            GameSet.HandCards.Add(new CardSet(CardType.ActionCard, ImagePaths.LampPickFix, 1));
            GameSet.HandCards.Add(new CardSet(CardType.ActionCard, ImagePaths.TrolleyPickFix, 1));
            GameSet.HandCards.Add(new CardSet(CardType.ActionCard, ImagePaths.Map, ActionType.Explore, 2));
            GameSet.HandCards.Add(new CardSet(CardType.ActionCard, ImagePaths.Key, ActionType.Key, 20));
            GameSet.HandCards.Add(new CardSet(CardType.ActionCard, ImagePaths.Bang, ActionType.DestroyConnection, 2));
        }

        protected override void PrepareGoldCard()
        {
            GameSet.GoldCards.Add(new CardSet(CardType.GoldCard, ImagePaths.Cross_0, RouteType.Cross));
            GameSet.GoldCards.Add(new CardSet(CardType.GoldCard, ImagePaths.FourDeadEnds_0, RouteType.FourDeadEnds));
            GameSet.GoldCards.Add(new CardSet(CardType.GoldCard, ImagePaths.ThreeDeadEndsLong_0, RouteType.ThreeDeadEndsLong));
            GameSet.GoldCards.Add(new CardSet(CardType.GoldCard, ImagePaths.ThreeDeadEndsShort_0, RouteType.ThreeDeadEndsShort));
            GameSet.GoldCards.Add(new CardSet(CardType.GoldCard, ImagePaths.LeftAngle_1, RouteType.LeftAngleGoldGreen, goldCount: 1, hasGates: true));
            GameSet.GoldCards.Add(new CardSet(CardType.GoldCard, ImagePaths.LeftAngle_2, RouteType.LeftAngleGold2, goldCount: 2));
            GameSet.GoldCards.Add(new CardSet(CardType.GoldCard, ImagePaths.RightAngle_1, RouteType.RightAngleGoldBlue, goldCount: 1, hasGates: true));
            GameSet.GoldCards.Add(new CardSet(CardType.GoldCard, ImagePaths.RightAngle_2, RouteType.RightAngleGold2, goldCount: 2));
            GameSet.GoldCards.Add(new CardSet(CardType.GoldCard, ImagePaths.TwoDeadEndsLeft_1, RouteType.TwoDeadEndsLeftGold, goldCount: 1));
            GameSet.GoldCards.Add(new CardSet(CardType.GoldCard, ImagePaths.TwoDeadEndsRight_3, RouteType.TwoDeadEndsRightGold3, goldCount: 3));
            GameSet.GoldCards.Add(new CardSet(CardType.GoldCard, ImagePaths.LongLineWithTwoDeadEnds_1, RouteType.LongLineWithTwoDeadEndsGold2, goldCount: 1));
            GameSet.GoldCards.Add(new CardSet(CardType.GoldCard, ImagePaths.ShortLineWithTwoDeadEnds_2, RouteType.ShortLineWithTwoDeadEndsGold2, goldCount: 2));
            GameSet.GoldCards.Add(new CardSet(CardType.GoldCard, ImagePaths.ThreeLinesLong_1, RouteType.ThreeLinesLongBlueGold, goldCount: 1, hasGates: true));
            GameSet.GoldCards.Add(new CardSet(CardType.GoldCard, ImagePaths.ThreeLinesLong_2, RouteType.ThreeLinesLongGreenGold2, goldCount: 2, hasGates: true));
            GameSet.GoldCards.Add(new CardSet(CardType.GoldCard, ImagePaths.ThreeLinesLong_3, RouteType.ThreeLinesLongBlueGold3, goldCount: 3, hasGates: true));
            GameSet.GoldCards.Add(new CardSet(CardType.GoldCard, ImagePaths.ThreeLinesShort_1, RouteType.ThreeLinesShortGreenGold, goldCount: 1, hasGates: true));
            GameSet.GoldCards.Add(new CardSet(CardType.GoldCard, ImagePaths.ThreeLinesShort_2, RouteType.ThreeLinesShortBlueGold2, goldCount: 2, hasGates: true));
            GameSet.GoldCards.Add(new CardSet(CardType.GoldCard, ImagePaths.ThreeLinesShort_3, RouteType.ThreeLinesShortGreenGold3, goldCount: 3, hasGates: true));
        }

        protected override void PrepareStartCards()
        {
            GameSet.StartCards.Add(new StartCard(100, RouteType.StartBlue, ImagePaths.StartBlue)
            {
                Coordinates = new Coordinates(0, 2),
                ConnectionBottom = ConnectionType.Blue,
                ConnectionLeft = ConnectionType.Blue,
                ConnectionRight = ConnectionType.Blue,
                ConnectionTop = ConnectionType.Blue,
                Role = RoleType.Blue,
                Color = ConnectionType.Blue,
            });
            GameSet.StartCards.Add(new StartCard(200, RouteType.StartGreen, ImagePaths.StartGreen)
            {
                Coordinates = new Coordinates(0, 4),
                ConnectionBottom = ConnectionType.Green,
                ConnectionLeft = ConnectionType.Green,
                ConnectionRight = ConnectionType.Green,
                ConnectionTop = ConnectionType.Green,
                Role = RoleType.Green,
                Color = ConnectionType.Green,
            });
        }

        protected override void PrepareGoldCardCoordinates()
        {
            GameSet.GoldCardCoordinates.Add(new Coordinates(6, 1));
            GameSet.GoldCardCoordinates.Add(new Coordinates(6, 3));
            GameSet.GoldCardCoordinates.Add(new Coordinates(6, 5));
            GameSet.GoldCardCoordinates.Add(new Coordinates(8, 2));
            GameSet.GoldCardCoordinates.Add(new Coordinates(8, 4));
            GameSet.GoldCardCoordinates.Add(new Coordinates(10, 3));
        }
    }
}
