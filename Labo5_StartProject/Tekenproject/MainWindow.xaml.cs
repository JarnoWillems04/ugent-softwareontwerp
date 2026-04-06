using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;
using Tekenproject.Pattern;

namespace Tekenproject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DrawLogic receiver;

        CommandInvoker invoker = new();

        public MainWindow()
        {
            InitializeComponent();
            receiver = new DrawLogic(this);
            TekenCanvas.Focus();
        }
       
        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TekenCanvas.CaptureMouse();
            receiver.MouseDown(e.GetPosition(TekenCanvas));
        }

        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            TekenCanvas.ReleaseMouseCapture();
            Shape shape = receiver.MouseUp(e.GetPosition(TekenCanvas));
            invoker.Execute(new DrawCommand(receiver, shape));
        }

        private void Canvas_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.F:
                    invoker.Execute(new ToggleFillCommand(receiver));
                    break;

                case Key.S:
                    invoker.Execute(new ToggleStrokeCommand(receiver));
                    break;
                case Key.R:
                    invoker.Execute(new ResetWindowCommand(receiver));
                    break;
                case Key.U:
                    invoker.Undo();
                    break;
                case Key.Z:
                    invoker.Redo();
                    break;
            }

        }


        private void BtnFill_Click(object sender, RoutedEventArgs e)
        {
            invoker.Execute(new ToggleFillCommand(receiver));
        }

        private void BtnStroke_Click(object sender, RoutedEventArgs e)
        {
            invoker.Execute(new ToggleStrokeCommand(receiver));
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            invoker.Execute(new ResetWindowCommand(receiver));
        }

        private void BtnUndo_Click(object sender, RoutedEventArgs e)
        {
            invoker.Undo();
        }
        private void BtnRedo_Click(object sender, RoutedEventArgs e)
        {
            invoker.Redo();
        }
    }
}
