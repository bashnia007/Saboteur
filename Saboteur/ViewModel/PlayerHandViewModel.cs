using System.Collections.ObjectModel;
using System.Windows.Input;
using CommonLibrary.CardsClasses;
using Saboteur.MVVM;

namespace Saboteur.ViewModel
{
    public class PlayerHandViewModel : ViewModelBase
    {
        public ObservableCollection<HandCard> Cards { get; set; }
        public Card SelectedCard { get; set; }

        private bool _isMyHand;

        public PlayerHandViewModel(bool isMyHand)
        {
            Cards = new ObservableCollection<HandCard>();
            Cards.Add(new HandCard(1));
            Cards.Add(new HandCard(2));
            Cards.Add(new HandCard(3));
            Cards.Add(new HandCard(4));
            Cards.Add(new HandCard(5));
            Cards.Add(new HandCard(6));

            _isMyHand = isMyHand;
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
