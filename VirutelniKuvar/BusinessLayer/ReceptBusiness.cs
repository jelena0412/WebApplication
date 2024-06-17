using DataLayer.Models;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Contexts;

namespace BusinessLayer
{
    public class ReceptBusiness
    {

        readonly ReceptRepository receptRepository= new ReceptRepository();
        readonly StavkeRepository stavkeRepository = new StavkeRepository();
        readonly SastojakRepository sastojakRepository = new SastojakRepository();
        readonly StavkaBusiness stavkaBusiness= new StavkaBusiness();
        public ReceptBusiness()
        {
            
        }

        public List<Recept> GetAllRecepti()
        {
            return this.receptRepository.GetAllRecepti();
        }
        public List<string> GetAllReceptNames()
        {
            var recepti = receptRepository.GetAllRecepti();

            List<string> receptNames = new List<string>();

            foreach (var recept in recepti)
            {
                receptNames.Add(recept.Naziv);
            }

            return receptNames;
        }
        public Recept GetReceptDetaljiByNaziv(string nazivRecepta)
        {
            var recepti = PretragaRecepataPoNazivu(nazivRecepta);

            if (recepti.Count == 0)
            {
                return null;
            }

            return recepti[0];
        }

        public List<Recept> PretragaRecepataPoNazivu(string naziv)
            {
            var recepti = receptRepository.GetAllRecepti();

            var query = from recept in recepti
                            join stavka in stavkeRepository.GetAllStavka() on recept.Id equals stavka.id_recepta
                            join sastojak in sastojakRepository.GetAllSastojci() on stavka.id_sastojka equals sastojak.Id
                            where recept.Naziv.ToLower().Contains(naziv.ToLower())
                            select new
                            {
                                id = recept.Id,
                                naziv = recept.Naziv,
                                opis = recept.Opis,
                                ocena = recept.Ocena,
                                komentar = recept.Komentar,
                                id_stavke = stavka.Id,
                                kolicina = stavka.kolicina,
                                id_sastojka = sastojak.Id,
                                naziv_sastojka = sastojak.naziv_sastojka,
                                mera = sastojak.mera
                            };

                var groupedData = query.GroupBy(data => new { data.id, data.naziv, data.opis, data.ocena, data.komentar })
                                      .Select(group => new Recept
                                      {
                                          Id = group.Key.id,
                                          Naziv = group.Key.naziv,
                                          Opis = group.Key.opis,
                                          Ocena = group.Key.ocena,
                                          Komentar = group.Key.komentar,
                                          Stavka = group.Select(stavkaData => new Stavka
                                          {
                                              Id = stavkaData.id,
                                              kolicina = stavkaData.kolicina,
                                              Sastojak = new Sastojak
                                              {
                                                  Id = stavkaData.id,
                                                  naziv_sastojka = stavkaData.naziv_sastojka,
                                                  mera = stavkaData.mera
                                              }
                                          }).ToList()
                                      }).ToList();

                return groupedData;
            }

        public int InsertRecept(Recept recept)
        {

            
            return this.receptRepository.InsertRecept(recept);
        }
        public bool UpdateRecept(Recept recept)
        {
            if (this.receptRepository.UpdateRecept(recept) > 0)
            {
                return true;
            }
            return false;
        }
        
    }
}
