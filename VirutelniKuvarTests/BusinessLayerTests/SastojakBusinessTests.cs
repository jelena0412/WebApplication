using System;
using System.Collections.Generic;
using BusinessLayer;
using DataLayer;
using DataLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLayerTests
{
    [TestClass]
    public class SastojakBusinessTests
    {
        private SastojakBusiness sastojakBusiness;

        [TestInitialize]
        public void Setup()
        {
            sastojakBusiness = new SastojakBusiness();
        }

        [TestMethod]
        public void GetAllSastojci_ShouldReturnListOfSastojci()
        {
            var result = sastojakBusiness.GetAllSastojci();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<Sastojak>));
          
        }

        [TestMethod]
        public void GetSastojakByName_ShouldReturnListOfSastojci()
        {
           
            string naziv = "Test Sastojak";

            
            var result = sastojakBusiness.GetSastojakByName(naziv);

            
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<Sastojak>));
           
        }

        [TestMethod]
        public void InsertSastojak_ShouldReturnPositiveId()
        {
           
            Sastojak sastojak = new Sastojak
            {
                naziv_sastojka = "Test Sastojak",
                mera = "kg"
            };

           
            var result = sastojakBusiness.InsertSastojak(sastojak);

           
            Assert.IsTrue(result > 0, "InsertSastojak should return a positive ID for a successful insert.");
        }


        [TestMethod]
        public void UpdateSastojak_ShouldReturnTrue()
        {
            
            Sastojak sastojak = new Sastojak
            {
                Id = 1, 
                naziv_sastojka = "Updated Sastojak",
                mera = "g"
            };

            var result = sastojakBusiness.UpdateSastojak(sastojak);

            Assert.IsTrue(result);
        }
    }
}
