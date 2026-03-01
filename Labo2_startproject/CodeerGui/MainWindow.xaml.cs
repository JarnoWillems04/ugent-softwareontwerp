using Codering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace CodeerGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CodeerHelper codeerhelper = new CodeerHelper();
        ICodering codering;

        public MainWindow()
        {
            InitializeComponent();            
            Blok.IsChecked = true;
            codering = codeerhelper["Blok"];
        }

        private void Invoer_TextChanged(object sender, TextChangedEventArgs e)
        {
            string zin = invoer.Text;
            if (zin != null)
            {
                uitvoer.Text = codering.Codeer(zin);
            }            
        }

        private void Radio_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            string? type = button.Content.ToString();
            if (type != null)
            {
                codering = codeerhelper[type];
                uitvoer.Text = codering.Codeer(invoer.Text);
            }
        }
    }
}
