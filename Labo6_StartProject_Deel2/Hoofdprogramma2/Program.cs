using GebruikersPortaal;
using Samenwerken;
using UserDatabase;

try
{
    Console.WriteLine("***********MySQLDataBaser********");

    TelUsers(SingletonDatabase.Instance);

    Console.WriteLine("***********Adapter UserToGebruiker********");
    IGebruikersLijst gebruikersLijst = new UserToGebruiker(SingletonDatabase.Instance);
    gebruikersLijst.VoegToe(new Gebruiker
    {
        Achternaam = "Jansen",
        VoorNaam = "Jan",
        GebruikersCode = 586
    });
    TelUsers(SingletonDatabase.Instance);

    //toegevoegd voor tweede adapter
    Console.WriteLine("***********Adapter GebruikerToUser ********");
    IDatabase db2 = new GebruikerToUser(gebruikersLijst);
    db2.InsertUser(new User() { ID = 1, FirstName = "John", LastName = "Doe" });
    TelUsers(SingletonDatabase.Instance);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

static void TelUsers(IDatabase db)
{
    Console.WriteLine(db.SelectAllUsers().Count + " users");
}

