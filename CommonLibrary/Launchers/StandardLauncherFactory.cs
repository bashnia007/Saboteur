using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibrary.GameSets;

namespace CommonLibrary.Launchers
{
    public class StandardLauncherFactory : AbstractLauncherFactory
    {
        public override AbstractGameSetFactory AbstractGameSetFactory => throw new NotImplementedException();

        public override AbstractLauncher CreateLauncher()
        {
            return new StandardLauncher(AbstractGameSetFactory.CreateGameSet());
        }
    }
}
