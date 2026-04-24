using System;
using System.Collections.Generic;
using System.Text;

using GebruikersPortaal;
using UserDatabase;


namespace Samenwerken
{
    public class UserToGebruiker : IGebruikersLijst
    {
        private IDatabase db;
        public UserToGebruiker(IDatabase db)
        {
            this.db = db;        
        }
        public Gebruiker[] Gebruikers { 
            
            get {
                checkConnection();
                List<User> users = db.SelectAllUsers();
                Gebruiker[] gebruikers = new Gebruiker[users.Count];
                int i = 0;
                foreach (User user in users)
                {
                    Gebruiker gebruiker = new Gebruiker();
                    gebruiker.GebruikersCode = user.ID;
                    gebruiker.VoorNaam = user.FirstName;
                    gebruiker.Achternaam = user.LastName;
                    Gebruikers[i] = gebruiker;
                    i++;
                }
                db.CloseConnection();
                return Gebruikers;
            } set; }


        public void VoegToe(Gebruiker gebruiker)
        {
            checkConnection();
            User user = transform(gebruiker);
            db.InsertUser(user);
            db.CloseConnection();
        }

        public void PasAan(Gebruiker gebruiker)
        {
            checkConnection();
            User user = transform(gebruiker);
            db.UpdateUser(user);
            db.CloseConnection();
        }

        public void Verwijder(Gebruiker gebruiker)
        {
            checkConnection();
            User user = transform(gebruiker);
            db.DeleteUser(user);
            db.CloseConnection();
        }

        private void checkConnection()
        {
            db.OpenConnection();
            if (!db.IsConnected)
                throw new Exception("Database is niet geconnecteerd");

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
