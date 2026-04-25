namespace Codering
{
    internal class NoCodering : ICodering
    {
        public override string ToString()
        {
            return "NoCodering";
        }
        public string Codeer(string zin)
        {
            return zin;
        }
    }
}
