using CommonLibraryStandard.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using XamarinApp.MVVM;

namespace XamarinApp.ViewModels
{
    public class CreateGameViewModel : ViewModelBase
    {
        #region Properties

        public List<GameType> GameTypes { get; set; }

        public GameType SelectedGameType { get; set; }

        #endregion

        #region Constructors

        public CreateGameViewModel()
        {
            GameTypes = ((GameType[])Enum.GetValues(typeof(GameType))).ToList();
        }

        #endregion

        #region Commands

        #region CreateGameCommand

        private RelayCommand _createGameCommand;
        public ICommand CreateGameCommand => _createGameCommand ?? 
            (_createGameCommand = new RelayCommand(ExecuteCreateGameCommand, CanExecuteCreateGameCommand));

        private void ExecuteCreateGameCommand(object obj)
        {
            throw new NotImplementedException();
        }

        private bool CanExecuteCreateGameCommand(object arg)
        {
            return true;
        }

        #endregion

        #endregion
    }
}
