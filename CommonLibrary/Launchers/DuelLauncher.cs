using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibrary.GameSets;

namespace CommonLibrary.Launchers
{
    [Serializable]
    public class DuelLauncher : AbstractLauncher
    {
        public DuelLauncher(IGameSet gameSet) : base(gameSet)
        {
        }
    }
}
