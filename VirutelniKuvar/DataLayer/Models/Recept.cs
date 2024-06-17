using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Recept
    {
        public int Id{ get; set; }

        public string Naziv { get; set; }

        public string Opis { get; set; }

        public string Komentar { get; set; }

        public int Ocena { get; set; }

        public int Id_korisnika { get; set; }
        public virtual ICollection<Stavka> Stavkaa { get; set; }

        public List<Stavka> Stavka { get; set; }
        public List<Sastojak> Sastojak { get; set; }
    }
}
