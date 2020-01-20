using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinApp.MVVM;
using XamarinApp.Views;

namespace XamarinApp.ViewModels
{
    public class LobbyViewModel : ViewModelBase
    {
        public TabbedPage TabbedPage { get; }

        public LobbyViewModel(string login)
        {
            TabbedPage = new LobbyPage();

            TabbedPage.Children.Add(new Profile
            {
                BindingContext = new ProfileViewModel()
            });
            TabbedPage.Children.Add(new Games
            {
                BindingContext = new GamesListViewModel()
            });
            TabbedPage.Children.Add(new Creategame
            {
                BindingContext = new CreateGameViewModel(TabbedPage)
            });
        }
    }
}
