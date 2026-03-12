using Druk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Drukmeter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            IDruk druk = new DrukPascal();
            InvoerControl ic = new(druk);
            UitvoerControl uc = new(druk);

            ColumnDefinition col = new();
            DrukGrid.ColumnDefinitions.Add(col);

            DrukGrid.Children.Add(ic);
            Grid.SetRow(ic, 0);
            Grid.SetColumn(ic, 0);

            DrukGrid.Children.Add(uc);
            Grid.SetRow(uc, 0);
            Grid.SetColumn(uc, 1);
        }
    }
}
