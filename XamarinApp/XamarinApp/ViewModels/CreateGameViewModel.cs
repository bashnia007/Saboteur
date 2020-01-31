using CommonLibraryStandard;
using CommonLibraryStandard.Enums;
using CommonLibraryStandard.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinApp.Models;
using XamarinApp.MVVM;
using XamarinApp.Services;

namespace XamarinApp.ViewModels
{
    public class CreateGameViewModel : ViewModelBase
    {
        #region Properties

        public List<GameType> GameTypes { get; set; }
        public List<GameMode> GameModes { get; set; }

        private GameType _selectedGameType;
        public GameType SelectedGameType
        {
            get
            {
                return _selectedGameType;
            }
            set
            {
                if (_selectedGameType != value)
                {
                    _selectedGameType = value;
                    switch(_selectedGameType)
                    {
                        case GameType.Duel:
                            MaxPlayers = 2;
                            break;
                        case GameType.Classic:
                            MaxPlayers = 10;
                            break;
                        case GameType.Extended:
                            MaxPlayers = 12;
                            break;
                        default: MaxPlayers = 2;
                            break;
                    }
                    OnPropertyChanged(nameof(SelectedGameType));
                    PlayersCount = 0;
                    OnPropertyChanged(nameof(MaxPlayers));
                }
            }
        }

        public GameMode SelectedGameMode { get; set; }

        public int MaxPlayers { get; set; }

        public int _playersCount;
        public int PlayersCount
        {
            get
            {
                return _playersCount;
            }
            set
            {
                if (value != _playersCount)
                {
                    _playersCount = value;
                    OnPropertyChanged(nameof(PlayersCount));
                }
            }
        }
        
        #endregion

        #region Private fields

        private TabbedPage _tabbedPage;

        #endregion

        #region Constructors

        public CreateGameViewModel(TabbedPage tabbedPage)
        {
            MaxPlayers = 2;
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
