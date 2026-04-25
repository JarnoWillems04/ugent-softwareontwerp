using Codering;
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
        CodeerHelper codeerHelper = new CodeerHelper();
        ICodering codeer;
        public MainWindow()
        {
            InitializeComponent();       
            InitButtons();        
            
        }

        private void InitButtons()
        {
            int i = 0;
            foreach (string type in codeerHelper.NamenCoderingen)
            {
                RadioButton button = new()
                {
                    Content = type,
                    GroupName = "codering"   ,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                 };
                button.Checked += Radio_Checked;
                ColumnDefinition col = new();
                GridCodeer.ColumnDefinitions.Add(col);
                GridCodeer.Children.Add(button);
                Grid.SetRow(button,0);
                Grid.SetColumn(button, i);
                if (i == 0)
                {
                    button.IsChecked = true;
                    codeer = codeerHelper[type];
                }
                i++;
            }
        }
   private void Invoer_TextChanged(object sender, TextChangedEventArgs e)
        {
            CodeerZin();
        }
        private void CodeerZin() { 
            string zin = invoer.Text;
            if (zin != null)
            {
                uitvoer.Text=codeer?.Codeer(zin);
            }            
        }

        
        private void Radio_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            string type = (string)button.Content;
            codeer = codeerHelper[type];
            CodeerZin();
       }


    }
}
