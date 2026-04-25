namespace Catalogus
{
    public class Tijdschrift 
    {
        public string Id { get; set; }
        public DateTime Jaartal { get; set; }
        public string Uitgeverij { get; set; }
        public string Titel {get;set;}

        public Tijdschrift()
        {
        }

        public  string Inhoud
        {
            get
            {
                return Id + ": \"" + Titel + "\", " + Jaartal.ToString("d/MM/yyyy H:mm:ss") + ", " + Uitgeverij;
            }
        }

        
    }
}
