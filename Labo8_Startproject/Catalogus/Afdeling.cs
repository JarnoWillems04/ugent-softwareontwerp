namespace Catalogus
{
    public class Afdeling : ABibComposite
    {        

        public Afdeling()
        {
            elementen = new List<IBibItem>();
        }
        public override string Inhoud
        {
            get
            {
                return Naam;
            }
        }

    }
}
