using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibrary.GameSets;

namespace CommonLibrary.Launchers
{
    public class DuelLauncherFactory : AbstractLauncherFactory
    {
        public override AbstractGameSetFactory AbstractGameSetFactory { get; }

        public DuelLauncherFactory()
        {
            AbstractGameSetFactory = new DuelGameSetFactory();
            AbstractGameSetFactory.CreateGameSet();
        }

        public override AbstractLauncher CreateLauncher()
        {
            return new DuelLauncher(AbstractGameSetFactory.CreateGameSet());
        }

    }
}
