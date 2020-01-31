using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Creategame : ContentPage
	{
		public Creategame ()
		{
			InitializeComponent ();
		}
        void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            slider.Value = Math.Round(e.NewValue);
        }
    }
}