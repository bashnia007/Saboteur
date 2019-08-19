using CommonLibrary;
using CommonLibrary.Enumerations;
using Saboteur.MVVM;

namespace Saboteur.Models
{
    public class ActionModel : ViewModelBase
    {
        public Player Player { get; }
        public Equipment Equipment { get; }
        public bool IsBroken { get; set; }

        public ActionType ActionType
        {
            get
            {
                switch (Equipment)
                {
                    case Equipment.Lamp: return IsBroken ? ActionType.FixLamp : ActionType.BreakLamp;
                    case Equipment.Pick: return IsBroken ? ActionType.FixPick : ActionType.BreakPick;
                    case Equipment.Trolley: return IsBroken ? ActionType.FixTrolly : ActionType.BreakTrolley;
                    default: return ActionType.SpyGoldCard;
                }
            }
        }

        public string ImagePath { get; set; }

        public ActionModel(Player player, Equipment equipment, string imagePath)
        {
            Player = player;
            Equipment = equipment;
            ImagePath = imagePath;
        }
    }
}
