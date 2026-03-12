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
        private IDruk druk;
        public InvoerControl(IDruk druk)
        {   
            InitializeComponent();
            this.druk = druk;
            druk.Register(this);
            LblEenheid.Content = this.druk.Eenheid;
            GroupBoxDruk.Header = "druk in " + this.druk.Naam;
            TxtWaarde.Text = Convert.ToString(this.druk.Druk);
            TxtMax.Text = Convert.ToString(this.druk.Max);
        }

        private void BtnVerlaag_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            druk.Druk--;
        }

        private void BtnVerhoog_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            druk.Druk++;
        }
        private void TxtWaarde_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                druk.Druk = double.Parse(TxtWaarde.Text);
                TxtWaarde.Text = Convert.ToString(druk.Druk);
            }
        }
        public void Update()
        {

        }

    }
}
