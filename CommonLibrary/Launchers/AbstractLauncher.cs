using CommonLibrary.GameSets;
using System;
using System.Collections.Generic;

namespace CommonLibrary.Launchers
{
    [Serializable]
    public abstract class AbstractLauncher
    {
        public IGameSet GameSet { get; }
        public GameTable GameTable { get; }

        public AbstractLauncher(IGameSet gameSet)
        {
            GameSet = gameSet;
            GameTable = new GameTable(GameSet);
        }

        public virtual void StartRound(List<Player> players)
        {
            ProvideCardsToPlayers(players);
        }

        protected abstract void ProvideCardsToPlayers(List<Player> players);
    }
}
