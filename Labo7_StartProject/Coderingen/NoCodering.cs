using Coderingen;

namespace Codering
{
    internal class NoCodering : ACodering
    {
        public override string ToString()
        {
            return "NoCodering";
        }

        public override string Codering(string zin)
        {
            return zin;
        }

        protected override bool BoolVervang()
        {
            return false;
        }
    }
}
