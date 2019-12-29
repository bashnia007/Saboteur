using CommonLibrary.CardsClasses;
using CommonLibrary.CardSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.GameSets
{
    public interface IGameSet
    {
        List<CardSet> HandCards { get; }
        List<CardSet> GoldCards { get; }
        List<StartCard> StartCards { get; }
        List<Coordinates> GoldCardCoordinates { get; }
    }
}
