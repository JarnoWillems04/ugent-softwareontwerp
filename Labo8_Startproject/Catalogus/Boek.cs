
namespace Catalogus
{
    public class Boek : ABibItem
    {
        public string Titel { get; set; }
        public string Auteur { get; set; }
        public string Uitgeverij { get; set; }
        public int Jaartal { get; set; }

        public override string Inhoud
        {
           get { return Id + ": \"" + Titel + "\", " + Auteur + ", " + Uitgeverij + ", " + Jaartal; }
        }


    }
}
