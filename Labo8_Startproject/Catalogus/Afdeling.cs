namespace Catalogus
{
    public class Afdeling : ABibComposite
    {
        public string Id { get; set; }
        public string Naam { get; set; }

        //public Afdeling() 
        //{
        //    elementen = new List<IBibItem>();
        //}
        public override string Inhoud
        {
            get
            {
                return Naam;
            }
        }

    }
}
