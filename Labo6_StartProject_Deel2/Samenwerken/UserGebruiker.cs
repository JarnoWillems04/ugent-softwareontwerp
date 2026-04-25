using GebruikersPortaal;
using UserDatabase;

namespace Samenwerken
{
    internal class UserGebruiker : User
    { 

        public UserGebruiker(Gebruiker gebruiker)
        {
            LastName = gebruiker.Achternaam;
            FirstName = gebruiker.VoorNaam;
            ID = gebruiker.GebruikersCode;
        }
    }
}