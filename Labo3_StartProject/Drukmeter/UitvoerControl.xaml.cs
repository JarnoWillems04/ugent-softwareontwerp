using Druk;
using System;

using System.Windows.Controls;


namespace Drukmeter
{
    /// <summary>
    /// Interaction logic for UitvoerControl.xaml
    /// </summary>
    public partial class UitvoerControl : UserControl
    {
       
        DrukPascal druk;
        public UitvoerControl()
        {

            InitializeComponent();
            druk = new DrukPascal();
            UpdateWijzer();
            Eenheid.Content = "Pascal";

        }

        private void UpdateWijzer()
        {
            double currentAngle = (5.0 / 4.0) * Math.PI - (druk.Druk / druk.Max) * (Math.PI * 3.0 / 2.0);
            Waarde.Content = druk.Druk;
            Wijzer.X2 = 100 + 60 * Math.Cos(currentAngle);
            Wijzer.Y2 = 100 - 60 * Math.Sin(currentAngle);
        }
    }
}
