using System.Collections.Generic;
using CommonLibrary.CardsClasses;

namespace CommonLibrary.CardSets
{
    public interface IGameSet
    {
        List<CardSet> CardSets { get; }
        List<Coordinates> GoldCardCoordinates { get; }
        List<RouteCard> StartCards { get; }
    }
}