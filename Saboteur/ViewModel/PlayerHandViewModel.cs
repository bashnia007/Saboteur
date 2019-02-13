﻿using System.Collections.ObjectModel;
using CommonLibrary;
using CommonLibrary.CardsClasses;
using CommonLibrary.Enumerations;
using Saboteur.Models;
using Saboteur.MVVM;

namespace Saboteur.ViewModel
{
    public class PlayerHandViewModel : ViewModelBase
    {
        private Player _player;
        public ObservableCollection<HandCard> Cards { get; set; }
        public bool IsMyHand { get; set; }
        public ActionModel Lamp { get; set; }
        public ActionModel Pick { get; set; }
        public ActionModel Trolley{ get; set; }
        public ActionModel Prison{ get; set; }

        public PlayerHandViewModel(bool isMyHand, Player player)
        {
            Cards = new ObservableCollection<HandCard>();
            Cards.Add(new HandCard(1));
            Cards.Add(new HandCard(2));
            Cards.Add(new HandCard(3));
            Cards.Add(new HandCard(4));
            Cards.Add(new HandCard(5));
            Cards.Add(new HandCard(6));
            IsMyHand = isMyHand;
            _player = player;
            Lamp = new ActionModel(player, Equipment.Lamp);
            Pick = new ActionModel(player, Equipment.Pick);
            Trolley = new ActionModel(player, Equipment.Trolley);
            Prison = new ActionModel(player, Equipment.Prison);
        }

        #region Commands

        #endregion
    }
}
