using System;
using System.Collections.Generic;
using System.Text;
using UserDatabase;

//1e check  →  Snelle check, lock vermijden als het al bestaat
//lock      →  Maar één thread tegelijk mag aanmaken
//2e check  →  Voorkomt dubbele aanmaak als threads elkaar kruisen

namespace Samenwerken
{
    public sealed class SingletonDatabase : IDatabase
    {
        private static volatile SingletonDatabase? instance;
        private static object blockObj = new object();

        private readonly IDatabase db;

        public bool IsConnected => true; //always connected

        private SingletonDatabase() 
        {
            db = new MySQLDatabase();
            db.OpenConnection();
        }

        public static IDatabase Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (blockObj)
                    {
                        if (instance == null)
                        {
                            instance = new SingletonDatabase();                            
                        }
                    }
                }

                return instance;
            }
        }

        ~SingletonDatabase()
        {
            db.CloseConnection();
        }

        public void CloseConnection()
        {
            Console.WriteLine("MySQLDatabank niet sluiten");
        } //niets doen

        public void DeleteUser(User user) => db.DeleteUser(user);

        public void InsertUser(User user) => db.InsertUser(user);

        public void OpenConnection() { }//connectie is altijd open

        public List<User> SelectAllUsers() => db.SelectAllUsers();

        public void UpdateUser(User user) => db.UpdateUser(user);
    }
}
