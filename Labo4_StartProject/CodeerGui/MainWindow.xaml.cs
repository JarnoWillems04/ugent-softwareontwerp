
using Codering;
using System.Windows;
using System.Windows.Controls;

namespace CodeerGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CodeerHelper codeerHelper = new();
        ICodering codeer;
        public MainWindow()
        {
            InitializeComponent();
            codeer = new Tekst();
            InitButtons();
        }

        private void InitButtons()
        {
            int i = 0;
            foreach (string type in codeerHelper.NamenCoderingen)
            {
                Button button = new()
                {
                    Content = type,
                    Width = 100,
                    Height = 50,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                };
                button.Click += Button_Click;
                ColumnDefinition col = new();
                GridCodeer.ColumnDefinitions.Add(col);
                GridCodeer.Children.Add(button);
                Grid.SetRow(button, 0);
                Grid.SetColumn(button, i);                
                i++;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string? type = button.Content.ToString();
            if (type != null) {
                codeer = codeerHelper.AddCodering(type, codeer);
                CodeerZin();
            }
        }

        private void Invoer_TextChanged(object sender, TextChangedEventArgs e)
        {     
            CodeerZin();
        }

        private void CodeerZin()
        {
            string zin = invoer.Text;
            if (zin != null)
            {
                uitvoer.Text = codeer?.Codeer(zin);
            }
        }

        private void VerwijderAlles(object sender, RoutedEventArgs e)
        {

            codeer = new Tekst();
            CodeerZin();
        }
        private void VerwijderLaatste(object sender, RoutedEventArgs e)
        {

            codeer = codeer.InterneCodering;
            CodeerZin();
        }

    }
}
