using CommonLibrary.CardsClasses;
using System;
using System.Collections.Generic;

namespace CommonLibrary.GameSets
{
    [Serializable]
    public class DuelGameSet : IGameSet
    {
        public List<CardSet> HandCards { get; }
        public List<CardSet> GoldCards { get; }

        public List<StartCard> StartCards { get; }

        public List<Coordinates> GoldCardCoordinates { get; }

        public List<RoleCard> Roles { get; }

        public DuelGameSet()
        {
            HandCards = new List<CardSet>();
            GoldCards = new List<CardSet>();
            StartCards = new List<StartCard>();
            GoldCardCoordinates = new List<Coordinates>();
            Roles = new List<RoleCard>();
        }
    }
}
