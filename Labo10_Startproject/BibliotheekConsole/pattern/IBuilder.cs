using Catalogus;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotheekConsole.pattern
{
    public interface IBuilder
    {
        public void NewLibrary(string id, string name);
        public void StartAfdeling(string id, string name);
        public void EndAfdeling();
        public void StartTijdschrift(string id, string title, DateTime jaartal, string uitgeverij);
        public void EndTijdschrift();
        public void AddArtikel(string id, string titel, string auteur);
        public void AddBoek(string id, string titel, string auteur, string uitgeverij, int jaartal);
        public IBibItem Build();
    }
}
