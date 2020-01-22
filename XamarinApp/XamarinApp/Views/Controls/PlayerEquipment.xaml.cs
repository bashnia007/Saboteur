using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinApp.Views.Controls
{
	public partial class PlayerEquipment : Grid
	{
		public PlayerEquipment ()
		{
			InitializeComponent ();
		}

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

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

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
            }
        }
    }
}