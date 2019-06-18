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
        
        #endregion
    }
}
