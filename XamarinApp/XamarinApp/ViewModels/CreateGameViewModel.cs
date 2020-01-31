using CommonLibraryStandard.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinApp.MVVM;
using XamarinApp.Services;

namespace XamarinApp.ViewModels
{
    public class CreateGameViewModel : ViewModelBase
    {
        #region Properties

        public List<GameType> GameTypes { get; set; }
        public List<GameMode> GameModes { get; set; }

        public GameType SelectedGameType { get; set; }

        public GameMode SelectedGameMode { get; set; }

        #endregion

        #region Private fields

        private TabbedPage _tabbedPage;

        #endregion

        #region Constructors

        public CreateGameViewModel(TabbedPage tabbedPage)
        {
            GameTypes = ((GameType[])Enum.GetValues(typeof(GameType))).ToList();
            GameModes = ((GameMode[])Enum.GetValues(typeof(GameMode))).ToList();
            _tabbedPage = tabbedPage;
        }

        #endregion

        #region Commands

        #region CreateGameCommand

        private RelayCommand _createGameCommand;
        public ICommand CreateGameCommand => _createGameCommand ?? 
            (_createGameCommand = new RelayCommand(ExecuteCreateGameCommand, CanExecuteCreateGameCommand));

        private void ExecuteCreateGameCommand(object obj)
        {
            GameViewModel gameVm;
            switch (SelectedGameMode)
            {
                case GameMode.Single:
                    gameVm = new GameViewModel(new SingleGame());
                    break;
                case GameMode.Multiplayer:
                    gameVm = new GameViewModel(new MultiPlayerGame());
                    break;
                default:
                    throw new NotImplementedException();
            }
            _tabbedPage.Navigation.PushAsync(gameVm.GamePage);
        }

        private bool CanExecuteCreateGameCommand(object arg)
        {
            return true;
        }

        #endregion

        #endregion
    }
}
