using System.Windows;
using System.Windows.Input;
using Saboteur.MVVM;

namespace Saboteur.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        #region Properties

        public string Login { get; set; }

        #endregion

        #region Private fileds

        private readonly Window _loginWindow;
        
        #endregion

        public LoginViewModel(Window loginWindow)
        {
            _loginWindow = loginWindow;
        }

        #region Commands

        #region JoinCommand

        private RelayCommand _joinCommand;

        public ICommand JoinCommand => _joinCommand ?? (_joinCommand =
                                            new RelayCommand(ExecuteJoinCommand, CanExecuteJoinCommand));

        private void ExecuteJoinCommand(object obj)
        {
            var mainViewModel = new MainViewModel(Login);
            mainViewModel.Window.Show();
            _loginWindow.Close();
        }

        private bool CanExecuteJoinCommand(object obj)
        {
            return !string.IsNullOrWhiteSpace(Login);
        }

        #endregion

        #endregion
    }
}
