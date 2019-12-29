using CommonLibrary.GameSets;
using System;

namespace CommonLibrary.Launchers
{
    [Serializable]
    public abstract class AbstractLauncher
    {
        public IGameSet GameSet { get; }

        public AbstractLauncher(IGameSet gameSet)
        {
            GameSet = gameSet;
        }

        public virtual void StartRound()
        {

        }
    }
}
