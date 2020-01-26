using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinApp.Models;
using XamarinApp.MVVM;
using XamarinApp.Views;

namespace XamarinApp.ViewModels
{
    public class GameViewModel : ViewModelBase
    {
        #region Properties

        public ContentPage GamePage { get; private set; }

        public List<List<ImageWithCoordinates>> Images { get; set; }

        public HandModel HandModel { get; set; }
        
        #endregion

        #region Constructors
        
        public GameViewModel()
        {
            GamePage = new GamePage();
            GamePage.BindingContext = this;

            Images = new List<List<ImageWithCoordinates>>();
            for (int y = 0; y < 7; y++)
            {
                var list = new List<ImageWithCoordinates>();
                for (int x = 0; x < 11; x++)
                {
                    list.Add(new ImageWithCoordinates("Cross.png", x, y));
                }
                Images.Add(list);
            }
            OnPropertyChanged(nameof(Images));

            HandModel = new HandModel();
            HandModel.Cards = new List<string>();

            for (int i = 0; i < 6; i++)
            {
                HandModel.Cards.Add("Cross.png");
            }
            HandModel.RoleImage = "blue_dwarf.png";

            OnPropertyChanged(nameof(HandModel));
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
