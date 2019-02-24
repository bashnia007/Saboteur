using CommonLibrary;
using CommonLibrary.Enumerations;
using Saboteur.MVVM;

namespace Saboteur.Models
{
    public class ActionModel : ViewModelBase
    {
        public Player Player { get; }
        public Equipment Equipment { get; }
        public string ImagePath { get; set; }

        public ActionModel(Player player, Equipment equipment, string imagePath)
        {
            Player = player;
            Equipment = equipment;
            ImagePath = imagePath;
        }
    }
}
