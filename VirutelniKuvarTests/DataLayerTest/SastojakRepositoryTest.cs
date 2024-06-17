using DataLayer;
using DataLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace DataLayerTests
{
    [TestClass]
    public class SastojakRepositoryTest
    {
        private SastojakRepository sastojakRepository;

        [TestInitialize]
        public void Init()
        {
            sastojakRepository = new SastojakRepository();
        }

        [TestMethod]
        public void GetAllSastojciTest()
        {
          
            Sastojak sastojak = new Sastojak
            {
                naziv_sastojka = "Test Sastojak",
                mera = "100g"
            };

            sastojakRepository.InsertSastojak(sastojak);

            Assert.IsNotNull(sastojakRepository.GetAllSastojci());

           
        }

        [TestMethod]
        public void UpdateSastojakTest()
        {
            Sastojak sastojak = new Sastojak
            {
                naziv_sastojka = "Test Sastojak",
                mera = "100g"
            };
            sastojakRepository.InsertSastojak(sastojak);

            List<Sastojak> sastojci = sastojakRepository.GetAllSastojci().ToList();
            if (sastojci.Any())
            {
                Sastojak updatedSastojak = sastojci.First();
                updatedSastojak.naziv_sastojka = "Izmenjeni Naziv Sastojka";
                int result = sastojakRepository.UpdateSastojak(updatedSastojak);

                Assert.IsTrue(result > 0);
            }

         
        }

       
    }
}
