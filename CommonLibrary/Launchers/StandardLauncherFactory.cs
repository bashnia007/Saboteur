using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Launchers
{
    public class StandardLauncherFactory : AbstractLauncherFactory
    {
        public override AbstractLauncher CreateLauncher()
        {
            return new StandardLauncher();
        }
    }
}
