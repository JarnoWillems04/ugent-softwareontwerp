using Catalogus;

namespace BibliotheekConsole.pattern
{
    internal class LibraryBuilder : IBuilder
    {
        ABibComposite root;
        readonly Stack<ABibComposite> afdelingenStack = new();


        public void NewLibrary(string id, string name)
        {
            root = new Afdeling() { Id = id, Naam = name };
            afdelingenStack.Push(root);


        }

        public void StartAfdeling(string id, string name)
        {
            Afdeling afdeling = new Afdeling() { Id = id, Naam = name };
            AddComposite(afdeling);

        }

        public void EndAfdeling()
        {
            afdelingenStack.Pop();


        }

        public void StartTijdschrift(string id, string title, DateTime jaartal, string uitgeverij)
        {
            TijdSchrift tijdschrift = new TijdSchrift() { Id = id, Titel = title, Jaartal = jaartal, Uitgeverij = uitgeverij };
            AddComposite(tijdschrift);

        }

        public void EndTijdschrift()
        {
            afdelingenStack.Pop();

        }

        public void AddArtikel(string id, string titel, string auteur)
        {
            Artikel artikel = new Artikel() { Id = id, Titel = titel, Auteur = auteur };
            afdelingenStack.Peek().VoegToe(artikel);
        }

        public void AddBoek(string id, string titel, string auteur, string uitgeverij, int jaartal)
        {
            Boek boek = new Boek() { Id = id, Titel = titel, Auteur = auteur, Uitgeverij = uitgeverij, Jaartal = jaartal };
            afdelingenStack.Peek().VoegToe(boek);

        }

        public IBibItem Build()
        {
            return root;
        }

        private void AddComposite(ABibComposite composite)
        {
            ABibComposite currentComposite = afdelingenStack.Peek();
            currentComposite.VoegToe(composite);
            composite.Ouder = currentComposite;
            afdelingenStack.Push(composite);
        }
    }
}
