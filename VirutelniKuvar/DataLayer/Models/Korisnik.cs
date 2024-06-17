using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Korisnik
    {
        public int id { get; set; }

        public string ime { get; set; }

        public string prezime { get; set; }

        public string korisnicko_ime { get; set; }

        public string mejl { get; set; }

        public string broj_telefona { get; set; }

        public string lozinka { get; set; }
    }
}
