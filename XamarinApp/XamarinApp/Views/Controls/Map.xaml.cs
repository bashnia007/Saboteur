using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Models;

namespace XamarinApp.Views.Controls
{
	public partial class Map : ScrollView
    {
		public Map ()
		{
			InitializeComponent ();
        }

        public static readonly BindableProperty ImagesProperty =
            BindableProperty.Create(nameof(Images), typeof(List<List<ImageWithCoordinates>>), typeof(Map), default(string), BindingMode.TwoWay);
        public List<List<ImageWithCoordinates>> Images
        {
            get
            {
                return (List<List<ImageWithCoordinates>>)GetValue(ImagesProperty);
            }

            set
            {
                SetValue(ImagesProperty, value);
            }
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            
            if (propertyName == ImagesProperty.PropertyName && Images.Count > 0)
            {                
                var rowDefinitions = new RowDefinitionCollection();
                for (int i = 0; i < Images.Count; i++)
                {
                    rowDefinitions.Add(new RowDefinition { Height = new GridLength(50, GridUnitType.Absolute) });
                }

                var columnDefinitions = new ColumnDefinitionCollection();
                for (int i = 0; i < Images[0].Count; i++)
                {
                    columnDefinitions.Add(new ColumnDefinition { Width = new GridLength(35, GridUnitType.Absolute) });
                }

                MapGrid.RowDefinitions = rowDefinitions;
                MapGrid.ColumnDefinitions = columnDefinitions;

                for (int x = 0; x < Images.Count; x++)
                {
                    var row = Images[0];
                    for (int y = 0; y < row.Count; y++)
                    {
                        MapGrid.Children.Add(new Image { Source = row[y].Image, Aspect=Aspect.AspectFill }, y, x);
                    }
                }
            }
        }
    }
}