using System.Windows;
using System.Windows.Input;
using Tekenproject.Pattern;

namespace Tekenproject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DrawLogic receiver;

        public MainWindow()
        {
            InitializeComponent();
            receiver = new DrawLogic(this);
            TekenCanvas.Focus();
        }

        #region MouseEvents       
        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TekenCanvas.CaptureMouse();
            receiver.MouseDown(e.GetPosition(TekenCanvas));
        }

        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            TekenCanvas.ReleaseMouseCapture();
            receiver.MouseUp(e.GetPosition(TekenCanvas));
        }

        #endregion
        private void Canvas_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.Key == Key.F)
                receiver.StrokeNr++;
           
        }


        private void BtnFill_Click(object sender, RoutedEventArgs e)
        {
            receiver.FillNr++;
        }

        private void BtnStroke_Click(object sender, RoutedEventArgs e)
        {
            receiver.StrokeNr++;
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            receiver.ClearCanvas();
        }

        private void BtnUndo_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BtnRedo_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
