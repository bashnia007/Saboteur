using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibrary.CardsClasses;
using CommonLibrary.CardSets;

namespace CommonLibrary.GameSets
{
    public class DuelGameSet : IGameSet
    {
        public List<CardSet> HandCards { get; }
        public List<CardSet> GoldCards { get; }

        public List<StartCard> StartCards { get; }

        public List<Coordinates> GoldCardCoordinates { get; }

        public DuelGameSet()
        {
            HandCards = new List<CardSet>();
            GoldCards = new List<CardSet>();
            StartCards = new List<StartCard>();
            GoldCardCoordinates = new List<Coordinates>();
        }
    }
}
