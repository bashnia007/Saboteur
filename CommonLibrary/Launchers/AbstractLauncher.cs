using CommonLibrary.GameSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Launchers
{
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
