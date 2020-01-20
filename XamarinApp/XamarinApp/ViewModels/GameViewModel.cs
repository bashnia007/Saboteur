using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinApp.MVVM;
using XamarinApp.Views;

namespace XamarinApp.ViewModels
{
    public class GameViewModel : ViewModelBase
    {
        #region Properties

        public ContentPage GamePage { get; private set; }

        #endregion

        #region Constructors
        
        public GameViewModel()
        {
            GamePage = new GamePage();
            GamePage.BindingContext = this;
        }
        
        #endregion

        #region Commands

        #region SelectImage

        private RelayCommand _selectImage;

        public ICommand SelectImage => _selectImage ?? (_selectImage = new RelayCommand(ExecuteSelectImage, CanExecuteSelectImage));

        private void ExecuteSelectImage(object obj)
        {
        }

        private bool CanExecuteSelectImage(object arg)
        {
            return true;
        }

        #endregion

        #endregion
    }
}
