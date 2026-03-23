using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Tekenproject.Pattern
{
    /*
     * Receiver
     * */
    public class DrawLogic
    {
        SolidColorBrush[] colors = { Brushes.Black, Brushes.White, Brushes.Gray, Brushes.Red, Brushes.Green, Brushes.Blue, Brushes.Yellow, Brushes.Purple, Brushes.Brown, Brushes.Orange };

        Random random = new Random();

        MainWindow window;
        int strokeNr = 0, fillNr = 1;

        Point start, einde;

        public DrawLogic(MainWindow window)
        {
            this.window = window;
        }
        
        internal SolidColorBrush StrokeColor => colors[StrokeNr];
        internal SolidColorBrush FillColor => colors[FillNr];

        internal int StrokeNr
        {
            get { return strokeNr; }
            set
            {
                strokeNr = value % colors.Length;
                window.BrushStroke.Color = StrokeColor.Color;
            }
        }

        internal int FillNr
        {
            get { return fillNr; }
            set
            {
                fillNr = value % colors.Length;
                window.BrushFill.Color = FillColor.Color;
            }
        }
        internal void ClearCanvas()
        {
            window.TekenCanvas.Children.Clear();
        }

        internal void AddDrawing(Shape shape)
        {
            window.TekenCanvas.Children.Add(shape);
        }

        internal void MouseDown(Point point)
        {
           start = point;
        }

        internal void MouseUp(Point point)
        {
            einde = point;

            einde = point;
            AddDrawing(GetShape());
        }

             
        private Shape GetShape()
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Width = Math.Abs(einde.X - start.X);
            ellipse.Height = Math.Abs(einde.Y - start.Y);            
            ellipse.Fill = FillColor;
            ellipse.Stroke = StrokeColor;
            Canvas.SetLeft(ellipse, Math.Min(start.X, einde.X));
            Canvas.SetTop(ellipse, Math.Min(start.Y, einde.Y));
            return ellipse;
        }        
    }

}