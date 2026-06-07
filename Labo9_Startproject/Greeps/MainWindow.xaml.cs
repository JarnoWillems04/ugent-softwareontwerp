using Greeps.Items;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Greeps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        readonly GreepsWorld world;
        readonly List<ItemImage> images;

        public MainWindow()
        {
            InitializeComponent();

            world = new GreepsWorld();
            images = FillImagesList(world.Items);

            // achtergrond canvas
            BitmapSource bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(world.Background.GetHbitmap(),
                IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            ImageBrush imageBrush = new ImageBrush(bitmapSource);
            canvas.Background = imageBrush;

            // timer
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DrawItems;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            dispatcherTimer.Start();
        }



        private List<ItemImage> FillImagesList(List<AItem> items)
        {
            List<ItemImage> itemImages = [];
            foreach (AItem item in items)
            {
                itemImages.Add(new ItemImage(item));
            }
            return itemImages;
        }

        private void DrawItems(object sender, EventArgs e)
        {
            canvas.Children.Clear();
            foreach (ItemImage image in images)
            {
                canvas.Children.Add(image);
                image.Act();
            }
        }
 
    }
}