using DataLayer.Models;
using DataLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace BusinessLayer
{
    public class StavkaBusiness
    {
        private readonly StavkeRepository stavkeRepository;

        public StavkaBusiness()
        {
            this.stavkeRepository = new StavkeRepository();
        }

        public List<Stavka> GetAllStavke()
        {
            return this.stavkeRepository.GetAllStavka();
        }

        public bool InsertStavke(Stavka stavke)
        {


            if (this.stavkeRepository.InsertStavke(stavke) > 0)
            {
                return true;
            }
            return false;
        }
        

        public bool UpdateStavke(Stavka stavke)
            {
                if (this.stavkeRepository.UpdateStavke(stavke) > 0)
                {
                    return true;
                }
                return false;
            }






        }

    }

