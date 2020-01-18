using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinApp.MVVM;
using XamarinApp.Views;

namespace XamarinApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        #region Properties

        public string Login { get; set; }

        #endregion

        #region Private fields

        private ContentPage _loginPage;

        #endregion

        #region Constructors

        public LoginViewModel(ContentPage page)
        {
            _loginPage = page;
        }
        
        #endregion

        #region JoinCommand

        private RelayCommand _joinCommand;

        public ICommand JoinCommand => _joinCommand ?? (_joinCommand =
                                            new RelayCommand(ExecuteJoinCommand, CanExecuteJoinCommand));

        private void ExecuteJoinCommand(object obj)
        {
            var vm = new LobbyViewModel(Login);
            App.Current.Properties.Add("Login", Login);

            _loginPage.Navigation.PushAsync(vm.TabbedPage);
        }

        private bool CanExecuteJoinCommand(object obj)
        {
            return true;
        }

        #endregion
    }
}
