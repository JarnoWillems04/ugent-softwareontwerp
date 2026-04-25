using GebruikersPortaal;
using System.Collections.Generic;
using UserDatabase;

namespace Samenwerken
{
    public class GebruikerToUser : IDatabase
    {
        private IGebruikersLijst gebruikerslijst;

        public GebruikerToUser(IGebruikersLijst gebruikerslijst)
        {
            this.gebruikerslijst = gebruikerslijst;

        }
        public bool IsConnected => true;

        public void CloseConnection()
        {
            //niets doen
        }

        public void DeleteUser(User user)
        {
            gebruikerslijst.Verwijder(transformGebruiker(user));
        }

        public void InsertUser(User user)
        {
            gebruikerslijst.VoegToe(transformGebruiker(user));
        }

        public void OpenConnection()
        {
            //niets doen
        }

        public List<User> SelectAllUsers()
        {
            List<User> lijst = new List<User>();
            foreach (Gebruiker gebruiker in gebruikerslijst.Gebruikers)
            {
                lijst.Add(transform(gebruiker));
            }
            return lijst;
        }

        public void UpdateUser(User user)
        {
            gebruikerslijst.PasAan(transformGebruiker(user));
        }

        private Gebruiker transformGebruiker(User user)
        {
            Gebruiker gebruiker = new Gebruiker();
            gebruiker.GebruikersCode = user.ID;
            gebruiker.VoorNaam  = user.FirstName ;
            gebruiker.Achternaam = user.LastName;
            return gebruiker;
        }

        private User transform(Gebruiker gebruiker)
        {
            User user = new User();
            user.ID = gebruiker.GebruikersCode;
            user.FirstName = gebruiker.VoorNaam;
            user.LastName = gebruiker.Achternaam;
            return user;
        }
    }
}