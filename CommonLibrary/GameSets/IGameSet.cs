using CommonLibrary.CardsClasses;
using System.Collections.Generic;

namespace CommonLibrary.GameSets
{
    public interface IGameSet
    {
        List<CardSet> HandCards { get; }
        List<CardSet> GoldCards { get; }
        List<StartCard> StartCards { get; }
        List<Coordinates> GoldCardCoordinates { get; }
        List<RoleCard> Roles { get; }
    }
}
