using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Greeps.Items
{
    public class ItemImage : Image
    {
        readonly AItem item;
        public ItemImage(AItem item)
        {
            this.item = item;
            Width = item.Size;
            Height = Width;
        }

        public void Act()
        {
            //nieuwe image die zal worden toegevoegd op het canvas wordt aangemaakt
            Uri uri = new(item.ImageFile, UriKind.Relative);
            BitmapImage image = new(uri);
            Source = image;
            // positie instellen op canvas
            Canvas.SetLeft(this, item.Location.X - Width / 2);
            Canvas.SetTop(this, item.Location.Y - Height / 2);
            // draaien over hoek
            RenderTransform = new RotateTransform(item.Angle%360);
            RenderTransformOrigin = new Point(0.5, 0.5);
            // actie door item
            item.Act();
        }
    }
}
