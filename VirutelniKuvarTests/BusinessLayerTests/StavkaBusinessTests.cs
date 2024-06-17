using System;
using System.Collections.Generic;
using BusinessLayer;
using DataLayer;
using DataLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLayerTests
{
    [TestClass]
    public class StavkaBusinessTests
    {
        private StavkaBusiness stavkaBusiness;

        [TestInitialize]
        public void Setup()
        {
            stavkaBusiness = new StavkaBusiness();
        }

        [TestMethod]
        public void GetAllStavke_ShouldReturnListOfStavke()
        {
          
            var result = stavkaBusiness.GetAllStavke();

           
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<Stavka>));
          
        }

        [TestMethod]
        public void InsertStavke_ShouldReturnTrue()
        {
            
            Stavka stavka = new Stavka
            {
                kolicina = "100",
                id_recepta = 1, 
                id_sastojka = 1 
            };

           
            var result = stavkaBusiness.InsertStavke(stavka);

          
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void UpdateStavke_ShouldReturnTrue()
        {
            
            Stavka stavka = new Stavka
            {
                Id = 1,
                kolicina = "200",
                id_recepta = 1, 
                id_sastojka = 1 
            };

            var result = stavkaBusiness.UpdateStavke(stavka);

            
            Assert.IsTrue(result);
        }
    }
}
