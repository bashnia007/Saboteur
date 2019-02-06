using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibrary.CardsClasses;
using Saboteur.MVVM;

namespace Saboteur.ViewModel
{
    public class PlayerHandViewModel : ViewModelBase
    {
        public ObservableCollection<HandCard> Cards { get; set; }

        public PlayerHandViewModel()
        {
            Cards = new ObservableCollection<HandCard>();
            Cards.Add(new HandCard());
        }
    }
}
