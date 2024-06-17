using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer
{
    public static class Sastojci
    {
        public static int TrenutniIDSastojka { get; private set; }

        public static void PostaviTrenutniSastojak(int idsastojka)
        {
            TrenutniIDSastojka = idsastojka;
        }
    }
}
