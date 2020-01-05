using CommonLibrary.GameSets;
using System;
using System.Collections.Generic;

namespace CommonLibrary.Launchers
{
    [Serializable]
    public abstract class AbstractLauncher
    {
        public GameTable GameTable { get; }

        public AbstractLauncher(IGameSet gameSet)
        {
            GameTable = new GameTable(gameSet);
        }

        public virtual void StartRound(List<Player> players)
        {
            ProvideCardsToPlayers(players);
        }

        protected abstract void ProvideCardsToPlayers(List<Player> players);
    }
}
