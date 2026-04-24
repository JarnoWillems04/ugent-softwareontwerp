// See https://aka.ms/new-console-template for more information

using GebruikersPortaal;
using UserDatabase;
using Samenwerken;

try
{
    Console.WriteLine("***********MySQLDataBaser********");

    IDatabase db = new MySQLDatabase();//enige database die gegeven is, implementeert IDatabase
    TelUsers(db);

    Console.WriteLine("***********Adapter UserToGebruiker********");
    IGebruikersLijst gebruikersLijst = new UserToGebruiker(db);
    gebruikersLijst.VoegToe(new Gebruiker
    {
        Achternaam = "Jansen",
        VoorNaam = "Jan",
        GebruikersCode = 586
    });
    TelUsers(db);

    //toegevoegd voor tweede adapter
    //Console.WriteLine("***********Adapter GebruikerToUser ********");
    //IDatabase db2 = new GebruikerToUser(gebruikersLijst);
    //db2.InsertUser(new User() { ID = 1, FirstName = "John", LastName = "Doe" });
    //TelUsers(db);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

static void TelUsers(IDatabase db)
{
    db.OpenConnection();
    Console.WriteLine(db.SelectAllUsers().Count + " users");
    db.OpenConnection();
}