namespace Catalogus
{
    public class Afdeling 
    {
        public string Id { get; set; }
        public string Naam { get; set; }
        public string Inhoud
        {
            get
            {
                return Naam;
            }
        }

    }
}
