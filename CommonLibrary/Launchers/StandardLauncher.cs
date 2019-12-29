using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibrary.GameSets;

namespace CommonLibrary.Launchers
{
    public class StandardLauncher : AbstractLauncher
    {
        public StandardLauncher(IGameSet gameSet) : base(gameSet)
        {
        }
    }
}
