using System.Windows;
using Saboteur.ViewModel;

namespace Saboteur
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

            DataContext = new LoginViewModel(this);
        }
    }
}
