using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirutelniKuvar
{
    public static class UserL
    {
        public static string TrenutnoKorisnickoIme { get; private set; }

        public static string TrenutnaLozinka { get; private set; }

        public static int TrenutniKorisnickiID { get; private set; }

        public static void PostaviTrenutnogKorisnika(string korisnicko_ime)
        {
            TrenutnoKorisnickoIme = korisnicko_ime;
        }

        public static void PostaviTrenutnogKorisnik(string lozinka)
        {
            TrenutnaLozinka = lozinka;
        }

        public static void PostaviTrenutniKorisnickiID(int id_korisnika)
        {
            TrenutniKorisnickiID = id_korisnika;
        }
    }
}
