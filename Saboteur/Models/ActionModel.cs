using CommonLibrary;
using CommonLibrary.Enumerations;

namespace Saboteur.Models
{
    public class ActionModel
    {
        public Player Player { get; }
        public Equipment Equipment { get; }

        public ActionModel(Player player, Equipment equipment)
        {
            Player = player;
            Equipment = equipment;
        }
    }
}
