using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibrary.CardsClasses;
using CommonLibrary.GameSets;

namespace CommonLibrary.Launchers
{
    [Serializable]
    public class DuelLauncher : AbstractLauncher
    {
        public DuelLauncher(IGameSet gameSet) : base(gameSet)
        {
        }
        
        protected override void ProvideCardsToPlayers(List<Player> players)
        {
            const int cardsOnHand = 6;
            for (int i = 0; i < players.Count(); i++)
            {
                var player = players[i];
                player.Role = (RoleCard) GameTable.Roles.Dequeue();

                for (int j = 0; j < cardsOnHand; j++)
                {
                    player.Hand.Add((HandCard) GameTable.HandCards.Dequeue());
                }
            }
        }
    }
}
