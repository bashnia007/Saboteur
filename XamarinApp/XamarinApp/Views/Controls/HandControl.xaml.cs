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
	public partial class HandControl : Grid
	{
		public HandControl ()
		{
			InitializeComponent ();
		}

        public static readonly BindableProperty HandCardsProperty =
            BindableProperty.Create(nameof(HandCards), typeof(HandModel), typeof(HandControl), default(string), BindingMode.TwoWay);
        public HandModel HandCards
        {
            get
            {
                return (HandModel)GetValue(HandCardsProperty);
            }

            set
            {
                SetValue(HandCardsProperty, value);
            }
        }
        
        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == HandCardsProperty.PropertyName && HandCards.Cards != null && HandCards.Cards.Count > 0)
            {
                var columnDefinitions = new ColumnDefinitionCollection();

                columnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100, GridUnitType.Absolute) });

                for (int i = 0; i < HandCards.Cards.Count; i++)
                {
                    columnDefinitions.Add(new ColumnDefinition { Width = new GridLength(35, GridUnitType.Absolute) });
                }

                var rowDefinitions = new RowDefinitionCollection();
                rowDefinitions.Add(new RowDefinition { Height = new GridLength(50, GridUnitType.Absolute) });

                Hand.ColumnDefinitions = columnDefinitions;
                Hand.RowDefinitions = rowDefinitions;

                Hand.Children.Add(new Image { Source = HandCards.RoleImage }, 0, 0);
                for (int i = 1; i < HandCards.Cards.Count+1; i++)
                {
                    Hand.Children.Add(new Image { Source = HandCards.Cards[i-1], Aspect = Aspect.AspectFill }, i, 0);
                }
            }
        }

    }
}