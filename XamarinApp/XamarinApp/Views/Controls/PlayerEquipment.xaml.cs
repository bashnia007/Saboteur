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
	public partial class PlayerEquipment : Grid
	{
		public PlayerEquipment ()
		{
			InitializeComponent ();
		}

        public static readonly BindableProperty EquipmentListProperty =
            BindableProperty.Create(nameof(EquipmentList), typeof(List<EquipmentModel>), typeof(PlayerEquipment), default(string), BindingMode.TwoWay);

        public List<EquipmentModel> EquipmentList
        {
            get
            {
                return (List<EquipmentModel>)GetValue(EquipmentListProperty);
            }
            set
            {
                SetValue(EquipmentListProperty, value);
            }
        }
        /*
        public static readonly BindableProperty LampProperty = 
            BindableProperty.Create(nameof(Lamp), typeof(string), typeof(PlayerEquipment), default(string), BindingMode.TwoWay);
        public string Lamp
        {
            get
            {
                return (string)GetValue(LampProperty);
            }

            set
            {
                SetValue(LampProperty, value);
            }
        }

        public static readonly BindableProperty PickProperty =
            BindableProperty.Create(nameof(Pick), typeof(string), typeof(PlayerEquipment), default(string), BindingMode.TwoWay);
        public string Pick
        {
            get
            {
                return (string)GetValue(PickProperty);
            }

            set
            {
                SetValue(PickProperty, value);
            }
        }

        public static readonly BindableProperty TrolleyProperty =
            BindableProperty.Create(nameof(Trolley), typeof(string), typeof(PlayerEquipment), default(string), BindingMode.TwoWay);
        public string Trolley
        {
            get
            {
                return (string)GetValue(TrolleyProperty);
            }

            set
            {
                SetValue(TrolleyProperty, value);
            }
        }
        */
        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == EquipmentListProperty.PropertyName)
            {
                var columnDefinitions = new ColumnDefinitionCollection();
                for (int i = 0; i < EquipmentList.Count; i++)
                {
                    columnDefinitions.Add(new ColumnDefinition { Width = new GridLength(41, GridUnitType.Absolute) });
                }

                var rowDefinitions = new RowDefinitionCollection();
                rowDefinitions.Add(new RowDefinition { Height = new GridLength(60, GridUnitType.Absolute) });

                EquipmentGrid.ColumnDefinitions = columnDefinitions;
                EquipmentGrid.RowDefinitions = rowDefinitions;

                for (int i = 0; i < EquipmentList.Count; i++)
                {
                    var tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandProperty, "SelectEquipment");
                    tapGestureRecognizer.CommandParameter = EquipmentList[i].Image;
                    var image = new Image
                    {
                        Source = EquipmentList[i].Image,
                        Aspect = Aspect.AspectFill,
                    };
                    image.GestureRecognizers.Add(tapGestureRecognizer);

                    EquipmentGrid.Children.Add(image, i, 0);
                }
            }

            /*
            if (propertyName == LampProperty.PropertyName)
            {
                LampImage.Source = Lamp;
            }
            else if (propertyName == PickProperty.PropertyName)
            {
                PickImage.Source = Pick;
            }
            else if (propertyName == TrolleyProperty.PropertyName)
            {
                TrolleyImage.Source = Trolley;
            }*/
        }
    }
}