using Xamarin.Forms;

namespace XamarinApp.Models
{
    public class ImageWithCoordinates
    {
        public string Image { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public ImageWithCoordinates(string image, int x, int y)
        {
            Image = image;
            X = x;
            Y = y;
        }
    }
}
