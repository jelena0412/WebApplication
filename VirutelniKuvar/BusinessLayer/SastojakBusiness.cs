using DataLayer.Models;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer
{
    public class SastojakBusiness
    {
        private readonly SastojakRepository sastojakRepository;
        readonly Sastojak sastojak = new Sastojak();

        public SastojakBusiness()
        {
            this.sastojakRepository = new SastojakRepository();
        }

        public List<Sastojak> GetAllSastojci()
        {
            return this.sastojakRepository.GetAllSastojci();
        }

        public List<Sastojak> GetSastojakByName(string naziv)
        { 
      
            return this.sastojakRepository.GetAllSastojci().Where(s => s.naziv_sastojka == naziv).ToList();
        }

        public int InsertSastojak(Sastojak sastojak)
        {
            

            return this.sastojakRepository.InsertSastojak(sastojak);

        }
        public bool UpdateSastojak(Sastojak sastojak)
        {
            if(this.sastojakRepository.UpdateSastojak(sastojak) > 0)
        {
                return true;
            }
            return false;
        }
       
    }
}
