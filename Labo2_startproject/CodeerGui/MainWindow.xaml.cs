using Codering;
using System;
using System.Collections.Generic;
using System.Linq;
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
            codering = codeerhelper["Blok"];
            InitButtons();
        }

        private void Invoer_TextChanged(object sender, TextChangedEventArgs e)
        {
            string zin = invoer.Text;
            if (zin != null)
            {
                uitvoer.Text = codering.Codeer(zin);
            }            
        }

        /*private void InitButtons()
        {
            var list = codeerhelper.NamenCoderingen.ToList();

            for (int i = 0; i < list.Count; i++)
            {
                var c = list[i];

                RadioButton button = new()
                {
                    Content = c,
                    GroupName = "buttons",
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    IsChecked = i == 0,                    
                };

                button.Checked += Radio_Checked;

                ColumnDefinition col = new();
                GridCodeer.ColumnDefinitions.Add(col);
               
                GridCodeer.Children.Add(button);
                Grid.SetRow(button, 0);
                Grid.SetColumn(button, i);
            }
        }*/

        private void InitButtons()
        {
            var list = codeerhelper.Coderingen.ToList();

            for (int i = 0; i < list.Count; i++)
            {
                ICodering codering = list[i];

                RadioButton button = new()
                {
                    Content = codering,
                    GroupName = "buttons",
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    IsChecked = i == 0,
                };

                button.Checked += Radio_Checked;

                ColumnDefinition col = new();
                GridCodeer.ColumnDefinitions.Add(col);

                GridCodeer.Children.Add(button);
                Grid.SetRow(button, 0);
                Grid.SetColumn(button, i);
            }
        }


        private void Radio_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            codering = (ICodering)button.Content;
            uitvoer.Text = codering.Codeer(invoer.Text);
        }
    }
}
