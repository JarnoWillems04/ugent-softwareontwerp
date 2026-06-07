using BibliotheekConsole;
using Catalogus;
using System.Diagnostics;
using System.Runtime.InteropServices;

DummyBibliotheek bib = new();
IBibItem start = bib.Bibliotheek;
Console.WriteLine(start.Toon(0));

IBibItem item = start.Zoek("ID07");
if (item != null)
{
    Console.WriteLine(item.Toon(0));
}
else
{
    Console.WriteLine("Item met id ID07 niet gevonden");
}

Console.WriteLine("Trefwoord zoek");

foreach (IBibItem ib in start.ZoekTrefwoord("en"))
{
    Console.WriteLine(ib.Toon(0));
}