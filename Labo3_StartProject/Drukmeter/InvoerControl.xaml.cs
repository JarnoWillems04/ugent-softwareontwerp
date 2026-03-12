using Druk;
using System;
using System.Windows.Controls;

namespace Drukmeter
{
    /// <summary>
    /// Interaction logic for InvoerControl.xaml
    /// </summary>
    public partial class InvoerControl : UserControl, IObserver
    {
        IDruk druk;
        public InvoerControl(IDruk druk)
        {   
            InitializeComponent();
            this.druk = druk;
            LblEenheid.Content = this.druk.Eenheid;
            GroupBoxDruk.Header = "druk in " + this.druk.Naam;
            TxtWaarde.Text = Convert.ToString(this.druk.Druk);
            TxtMax.Text = Convert.ToString(this.druk.Max);
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
