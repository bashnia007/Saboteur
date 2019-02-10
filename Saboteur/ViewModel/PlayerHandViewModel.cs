using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommonLibrary.CardsClasses;
using Saboteur.MVVM;

namespace Saboteur.ViewModel
{
    public class PlayerHandViewModel : ViewModelBase
    {
        public ObservableCollection<HandCard> Cards { get; set; }
        public Card SelectedCard { get; set; }

        public PlayerHandViewModel()
        {
            Cards = new ObservableCollection<HandCard>();
            Cards.Add(new HandCard());
            Cards.Add(new HandCard());
            Cards.Add(new HandCard());
            Cards.Add(new HandCard());
            Cards.Add(new HandCard());
            Cards.Add(new HandCard());
        }

        #region Commands

        #region MakeActionCommand

        private RelayCommand _makeActionCommand;

        public ICommand MakeActionCommand => _makeActionCommand ??
                                             (_makeActionCommand = new RelayCommand(ExecuteMakeActionCommand,
                                                 CanExecuteMakeActionCommand));

        public void ExecuteMakeActionCommand(object obj)
        {
            string command = obj.ToString();
        }

        public bool CanExecuteMakeActionCommand(object obj)
        {
            return SelectedCard != null;
        }

        #endregion

        #endregion
    }
}
