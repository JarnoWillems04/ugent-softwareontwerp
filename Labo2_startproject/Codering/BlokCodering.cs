using System;
using System.Collections.Generic;
using System.Text;

namespace Codering
{
    internal class BlokCodering : ICodering
    {
        public BlokCodering() {
            InitBlok();
        }

        private readonly Dictionary<char, int[]> letterLocatie = new Dictionary<char, int[]>();

        // static readonly om te voorkomen dat elke instantie een kopie heeft van deze tabel
        private static readonly char[,] code = new char[,]
          {{'a', 'z', 'e', 'r', 't', '1'},
        {'2', 'y', 'u', 'i', 'o', 'p'},
        {'q', '3', 's', '4', '8', 'd'},
        {'f', 'g', 'h', 'n', 'j', 'k'},
        {'9', '7', 'l', 'm', '6', 'w'},
        {'5', '0', 'x', 'c', 'v', 'b'}};

        private void InitBlok()
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

        public string Codeer(string zin) {
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

        private StringBuilder MaakEven(StringBuilder builder)
        {
            if (builder.Length % 2 == 1)
            {
                builder.Append(0);
            }
            return builder;
        }

        private StringBuilder VerwijderSpecialeTekens(StringBuilder builder)
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
