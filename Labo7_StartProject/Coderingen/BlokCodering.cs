using Coderingen;
using System.Text;

namespace Codering
{
    public class BlokCodering: ACodering
    {
        // static readonly om te voorkomen dat elke instantie een kopie heeft van deze tabel
        private static readonly char[,] code = new char[,]
          {{'a', 'z', 'e', 'r', 't', '1'},
        {'2', 'y', 'u', 'i', 'o', 'p'},
        {'q', '3', 's', '4', '8', 'd'},
        {'f', 'g', 'h', 'n', 'j', 'k'},
        {'9', '7', 'l', 'm', '6', 'w'},
        {'5', '0', 'x', 'c', 'v', 'b'}};

        private readonly Dictionary<char, int[]> letterLocatie = new();

        public BlokCodering()
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

        public override string ToString()
        {
            return "Blok";
        }
        public override string Codering(string zin)
        {
            // Encode sentence
            StringBuilder encoded = new StringBuilder(zin.Length);
            for (int i = 0; i < zin.Length; i += 2)
            {
                int[] loc1 = letterLocatie[zin[i]];
                int[] loc2 = letterLocatie[zin[i + 1]];
                encoded.Append(code[loc1[0], loc2[1]]);
                encoded.Append(code[loc2[0], loc1[1]]);
            }
            return encoded.ToString();
        }
    }
}
