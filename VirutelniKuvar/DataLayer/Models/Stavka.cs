using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Stavka
    {
        public int Id { get; set; }

        public string kolicina { get; set; }

        public int id_recepta { get; set; }

        public int id_sastojka { get; set; }
        
        public Sastojak Sastojak { get; set; }
    }
}
