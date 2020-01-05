using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibrary.GameSets;

namespace CommonLibrary.Launchers
{
    [Serializable]
    public class ExtendedLauncher : AbstractLauncher
    {
        public ExtendedLauncher(IGameSet gameSet) : base(gameSet)
        {
        }

        protected override void ProvideCardsToPlayers(List<Player> players)
        {
            throw new NotImplementedException();
        }
    }
}
