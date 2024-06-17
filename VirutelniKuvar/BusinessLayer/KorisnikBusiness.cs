using DataLayer.Models;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace BusinessLayer
{
    public  class KorisnikBusiness
    {
        private readonly KorisnikRepository korisnikRepository= new KorisnikRepository();

        public KorisnikBusiness()
        {
            this.korisnikRepository = new KorisnikRepository();
        }
        public KorisnikBusiness(KorisnikRepository korisnikRepository)
        {
            this.korisnikRepository = korisnikRepository;
        }

        public bool Prijava(string korisnicko_ime, string lozinka)
        {
            List<Korisnik> lista = this.korisnikRepository.GetAllUsers();
            bool p = false;
            foreach (Korisnik k in lista)
            {
                if (k.korisnicko_ime == korisnicko_ime && k.lozinka == lozinka)
                {
                    p = true;
                }
            }
            return p;
        }

        public int dajIDKorisnika(string korisnicko_ime, string lozinka)
        {
            List<Korisnik> lista = this.korisnikRepository.GetAllUsers();
            int id_kor = 0;
            foreach (Korisnik k in lista)
            {
                if (k.korisnicko_ime == korisnicko_ime && k.lozinka == lozinka)
                {
                    id_kor = k.id;
                }
            }
            return id_kor;
        }
        public bool ProveriPrijavu(string korisnickoIme, string lozinka)
        {
            if (string.IsNullOrEmpty(korisnickoIme) || string.IsNullOrEmpty(lozinka))
            {
                return false;
            }
            else
            {
                return korisnikRepository.ProveriKorisnika(korisnickoIme, lozinka);
            }
        }


        public List<Korisnik> GetAllUsers()
        {
            return this.korisnikRepository.GetAllUsers();
        }

        public bool InsertUser(Korisnik korisnik)
        {

            if (this.korisnikRepository.InsertUser(korisnik) > 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdateUser(Korisnik korisnik)
        {

            if (this.korisnikRepository.UpdateUser(korisnik) > 0)

            {
                return true;
            }
            return false;
        }

        public bool DeleteUser(int korisnikId)
        {
            if (this.korisnikRepository.DeleteUser(korisnikId) > 0)
            {
                return true;
            }
            return false;
        }
    }
}

   
