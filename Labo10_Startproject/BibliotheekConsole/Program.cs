// See https://aka.ms/new-console-template for more information

using BibliotheekConsole;
using Catalogus;

internal class Program
{
    private static void Main(string[] args)
    {
        //Dummy();
        YamlBibliotheek();
        void YamlBibliotheek()
        {
            YamlBibliotheek bib = new();
            IBibItem start = bib.Bibliotheek;
            Console.WriteLine(start.Toon(0));

        }
        void Dummy()
        {
            DummyBibliotheek bib = new();
            IBibItem start = bib.Bibliotheek;
            Console.WriteLine(start.Toon(0));

            IBibItem item = start.Zoek("ID07");
            Console.WriteLine(item.Toon(0) + "\n");

            Console.WriteLine("ZoekTrefwoord:");
      
            foreach (IBibItem ib in start.ZoekTrefwoord("en"))
            {
                Console.WriteLine(ib.Toon(0));
            }
        }
    }
}