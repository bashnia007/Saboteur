using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.ViewModels;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamarinApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new Views.GamePage());
            Init();
            //MainPage = new Views.LoginPage();
        }

        private void Init()
        {
            if (!App.Current.Properties.Keys.Contains("Login"))
            {
                MainPage = new NavigationPage(new Views.LoginPage());
            }
            else
            {
                string login = App.Current.Properties["Login"].ToString();
                var vm = new LobbyViewModel(login);
                MainPage = new NavigationPage(vm.TabbedPage);
            }
        }
        
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
