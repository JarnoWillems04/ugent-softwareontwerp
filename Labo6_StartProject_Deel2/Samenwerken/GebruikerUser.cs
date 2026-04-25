using GebruikersPortaal;
using UserDatabase;

namespace Samenwerken
{
    internal class GebruikerUser : Gebruiker
    {        

        public GebruikerUser(User user)
        {
            Achternaam = user.LastName;
            VoorNaam = user.FirstName;
            GebruikersCode = user.ID;
        }
    }
}