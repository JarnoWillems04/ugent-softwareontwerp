using Druk;
using System;
using System.Windows.Controls;

namespace Drukmeter
{
    /// <summary>
    /// Interaction logic for InvoerControl.xaml
    /// </summary>
    public partial class InvoerControl : UserControl
    {
        DrukPascal druk;
        public InvoerControl()
        {
            InitializeComponent();
            druk = new DrukPascal();
            LblEenheid.Content = druk.Eenheid;
            GroupBoxDruk.Header = "druk in " + druk.Naam;
            TxtWaarde.Text = Convert.ToString(druk.Druk);
            TxtMax.Text = Convert.ToString(druk.Max);
        }

        private void BtnVerlaag_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void BtnVerhoog_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
        private void TxtWaarde_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                druk.Druk = double.Parse(TxtWaarde.Text);
                TxtWaarde.Text = Convert.ToString(druk.Druk);
            }
        }
    }
}
