// See https://aka.ms/new-console-template for more information

using BibliotheekConsole;
using BibliotheekConsole.pattern;
//using BibliotheekConsole.Versie2;
using Catalogus;

//Dummy();
//YamlBibliotheek();

//YamBuilder2(); // met versie2
YamlBuilder();   //met pattern
void YamlBuilder()
{
    LibraryBuilder builder = new LibraryBuilder();
    LibraryDirector director = new LibraryDirector(builder);
    IBibItem start = director.BuildLibraryFromYAML("bestanden\\library.yaml");
    Console.WriteLine(start.Toon(0));
}


// Versie 2 - werkt enkel met versie2
/*void YamBuilder2()
{
    LibraryBuilder builder = new LibraryBuilder();
    IBibItem start =  builder.NewLibrary("BIB", "Bibliotheek")
            .StartAfdeling("ID1", "Afdeling 1")
                .StartTijdschrift("ID11", "Tijdschrift 1", new DateTime(2010, 1, 1), "Uitgeverij 1")
                    .AddArtikel("ID111", "Artikel 1", "Auteur 1")
                    .AddArtikel("ID112", "Artikel 2", "Auteur 2")
                    .AddArtikel("ID113", "Artikel 3", "Auteur 3")
                .EndTijdschrift()
                .StartTijdschrift("ID12", "Tijdschrift 2", new DateTime(2010, 1, 1), "Uitgeverij 1")
                    .AddArtikel("ID121", "Artikel 1", "Auteur 1")
                    .AddArtikel("ID122", "Artikel 2", "Auteur 2")
                    .AddArtikel("ID123", "Artikel 3", "Auteur 3")
                .EndTijdschrift()
                .StartTijdschrift("ID13", "Tijdschrift 3", new DateTime(2010, 1, 1), "Uitgeverij 1")
                    .AddArtikel("ID131", "Artikel 1", "Auteur 1")
                    .AddArtikel("ID132", "Artikel 2", "Auteur 2")
                    .AddArtikel("ID133", "Artikel 3", "Auteur 3")
                .EndTijdschrift()
                .AddBoek("ID14", "Boek 1", "Auteur 1", "Uitgeverij 1", 2020)
                .AddBoek("ID15", "Boek 2", "Auteur 2", "Uitgeverij 1", 2021)
                .AddBoek("ID16", "Boek 3", "Auteur 3", "Uitgeverij 1", 2022)
            .EndAfdeling()
            .StartAfdeling("ID2", "Afdeling 2")
                .StartTijdschrift("ID21", "Tijdschrift 1", new DateTime(2010, 1, 1), "Uitgeverij 1")
                    .AddArtikel("ID211", "Artikel 1", "Auteur 1")
                    .AddArtikel("ID212", "Artikel 2", "Auteur 2")
                    .AddArtikel("ID213", "Artikel 3", "Auteur 3")
                .EndTijdschrift()
                .AddBoek("ID22", "Boek 1", "Auteur 1", "Uitgeverij 2", 2019)
                .AddBoek("ID23", "Boek 2", "Auteur 2", "Uitgeverij 2", 2023)
            .EndAfdeling()
            .Build();
    Console.WriteLine(start.Toon(0));
}
*/

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