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
        public MainWindow()
        {
            InitializeComponent();
            InitBlok();
            InitRadio();
        }

        private string type = "Blok";

        private void Invoer_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }
        private void Radio_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            string? type = button.Content.ToString();
            if (type != null)
            {
                this.type = type;
                Update();
            }
        }

        private void Update()
        {
            string text = invoer.Text;

            string coded_text = type switch
            {
                "Blok" => BlokCodeer(text),
                "Wissel" => WisselCodeer(text),
                _ => CijferCodeer(text)
            };

            uitvoer.Text = coded_text;
        }


        private void InitRadio()
        {
            Blok.IsChecked = true;
        }


        // static readonly om te voorkomen dat elke instantie een kopie heeft van deze tabel
        private static readonly char[,] code = new char[,]
          {{'a', 'z', 'e', 'r', 't', '1'},
        {'2', 'y', 'u', 'i', 'o', 'p'},
        {'q', '3', 's', '4', '8', 'd'},
        {'f', 'g', 'h', 'n', 'j', 'k'},
        {'9', '7', 'l', 'm', '6', 'w'},
        {'5', '0', 'x', 'c', 'v', 'b'}};

        private static readonly Dictionary<char, int[]> letterLocatie = new Dictionary<char, int[]>();
        private static void InitBlok()
        {                       
            // opvullen dictionary om snel locatie van letter in code te vinden
            if (letterLocatie.Count == 0)
            {
                for (int i = 0; i < code.GetLength(0); i++)
                {
                    for (int j = 0; j < code.GetLength(1); j++)
                    {
                        char c = code[i, j];
                        letterLocatie.Add(c, new int[] { i, j });
                    }
                }
            }
        }
        public static string CijferCodeer(string zin)
        {
            StringBuilder result = new();
            for (int i = 0; i < zin.Length; i++)
            {
                int code = zin[i];
                result.Append(code);
            }
            return result.ToString();
        }

        public static string WisselCodeer(string zin)
        {
            // lengte even?
            if (zin.Length % 2 != 0)
            {
                zin += '0'; //minder goede oplossing - beter StringBuilder gebruiken
            }
            // codering door wisselen
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < zin.Length; i += 2)
            {
                // letters verwisselen
                result.Append(zin[i + 1]);
                result.Append(zin[i]);
            }
            return result.ToString();
        }


        

        public static string BlokCodeer(string zin)
        {
            // To LowerCase
            StringBuilder zinBuffer = new StringBuilder(zin.ToLower());

            // Append 0 to sentence with odd characters
            zinBuffer = MaakEven(zinBuffer);

            // Replace unknown characters
            zinBuffer = VerwijderSpecialeTekens(zinBuffer);

            string tekst = zinBuffer.ToString();

            // Encode sentence
            StringBuilder encoded = new StringBuilder(tekst.Length);
            for (int i = 0; i < tekst.Length; i += 2)
            {
                int[] loc1 = letterLocatie[tekst[i]];
                int[] loc2 = letterLocatie[tekst[i + 1]];
                encoded.Append(code[loc1[0], loc2[1]]);
                encoded.Append(code[loc2[0], loc1[1]]);
            }
            return encoded.ToString();
        }

        private static StringBuilder MaakEven(StringBuilder builder)
        {
            if (builder.Length % 2 == 1)
            {
                builder.Append(0);               
            }
            return builder;
        }

        private static StringBuilder VerwijderSpecialeTekens(StringBuilder builder)
        {
            // verwijder speciale tekens
            for (int i = 0; i < builder.Length; i++)
            {
                if (!char.IsLower(builder[i]) && !char.IsDigit(builder[i]))
                {
                    builder[i] = '0';
                }
            }
            return builder;
        }


    }
}
