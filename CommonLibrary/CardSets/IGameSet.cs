using System.Collections.Generic;

namespace CommonLibrary.CardSets
{
    public interface IGameSet
    {
        List<CardSet> CardSets { get; }
    }
}