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
            new CardSet(CardType.RouteCard, ImagePaths.ThreeLinesShort, 3),
            new CardSet(CardType.RouteCard, ImagePaths.ThreeLinesLong, 3),
            new CardSet(CardType.RouteCard, ImagePaths.LeftAngle, 3),
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
            new CardSet(CardType.ActionCard, ImagePaths.Bang, 2)
        };
    }
}
