using System.Collections.Generic;
using CommonLibrary;
using CommonLibrary.CardsClasses;
using CommonLibrary.Enumerations;
using Saboteur.Models;
using Saboteur.MVVM;
using System.Collections.ObjectModel;

namespace Saboteur.ViewModel
{
    public class PlayerHandViewModel : ViewModelBase
    {
        private Player _player;
        public ObservableCollection<HandCard> Cards { get; set; }
        public ObservableCollection<ActionModel> Actions { get; set; }
        public bool IsMyHand { get; set; }
        public ActionModel Lamp { get; set; }
        public ActionModel Pick { get; set; }
        public ActionModel Trolley{ get; set; }
        public ActionModel Prison{ get; set; }

        public PlayerHandViewModel(bool isMyHand, Player player)
        {
            Cards = new ObservableCollection<HandCard>();
            Actions = new ObservableCollection<ActionModel>();
            IsMyHand = isMyHand;
            _player = player;
            Lamp = new ActionModel(player, Equipment.Lamp, ImagePaths.LampFix);
            Pick = new ActionModel(player, Equipment.Pick, ImagePaths.PickFix);
            Trolley = new ActionModel(player, Equipment.Trolley, ImagePaths.TrolleyFix);
            Actions.Add(Lamp);
            Actions.Add(Pick);
            Actions.Add(Trolley);
            //Prison = new ActionModel(player, Equipment.Prison);
        }

        #region Commands

        #region RotateCard command

        #endregion

        #endregion

        #region Public methods

        public void UpdateCards(List<HandCard> cards)
        {
            Cards = new ObservableCollection<HandCard>(cards);
            OnPropertyChanged(nameof(Cards));
        }

        public void UpdateEquipment(List<Equipment> brokenEquipments)
        {
            if (brokenEquipments.Contains(Equipment.Lamp))
            {
                Lamp.ImagePath = ImagePaths.LampBreak;
                Lamp.IsBroken = true;
            }
            else
            {
                Lamp.ImagePath = ImagePaths.LampFix;
                Lamp.IsBroken = false;
            }

            if (brokenEquipments.Contains(Equipment.Pick))
            {
                Pick.ImagePath = ImagePaths.PickBreak;
                Pick.IsBroken = true;
            }
            else
            {
                Pick.ImagePath = ImagePaths.PickFix;
                Pick.IsBroken = false;
            }

            if (brokenEquipments.Contains(Equipment.Trolley))
            {
                Trolley.ImagePath = ImagePaths.TrolleyBreak;
                Trolley.IsBroken = true;
            }
            else
            {
                Trolley.ImagePath = ImagePaths.TrolleyFix;
                Trolley.IsBroken = false;
            }
            //Lamp.ImagePath = brokenEquipments.Contains(Equipment.Lamp) ? ImagePaths.LampBreak : ImagePaths.LampFix;
            //Pick.ImagePath = brokenEquipments.Contains(Equipment.Pick) ? ImagePaths.PickBreak : ImagePaths.PickFix;
            //Trolley.ImagePath = brokenEquipments.Contains(Equipment.Trolley) ? ImagePaths.TrolleyBreak : ImagePaths.TrolleyFix;
            OnPropertyChanged(nameof(Lamp));
            OnPropertyChanged(nameof(Pick));
            OnPropertyChanged(nameof(Trolley));
        }
        
        #endregion
    }
}
