using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirutelniKuvar
{
    public static class Recipes
    {
        public static int TrenutniIDRecepta { get; private set; }

        public static int TrenutniIDKorisnikaRecepta { get; private set; }
        public static string TrenutniNaziv { get; private set; }

        public static void PostaviTrenutniNaziv(string naziv)
        {
            TrenutniNaziv = naziv;
        }

        public static void PostaviTrenutniIDKorisnikaRecepta(int idkorisnika)
        {
            TrenutniIDKorisnikaRecepta = idkorisnika;
        }

        public static void PostaviTrenutniIDRecepta(int idRecepta)
        {
            TrenutniIDRecepta = idRecepta;
        }

        public static void ResetujTrenutniIDRecepta()
        {
            TrenutniIDRecepta = 0;
        }
    }
}
