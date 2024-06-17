using System;
using System.Collections.Generic;
using BusinessLayer;
using DataLayer;
using DataLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLayerTests
{
    [TestClass]
    public class ReceptBusinessTests
    {
        private ReceptBusiness receptBusiness;

        [TestInitialize]
        public void Setup()
        {
            // Initialize the ReceptBusiness class
            receptBusiness = new ReceptBusiness();
        }

        [TestMethod]
        public void GetAllRecepti_ShouldReturnListOfRecepti()
        {
            // Act
            var result = receptBusiness.GetAllRecepti();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<Recept>));
            // Add more assertions as needed based on the expected behavior
        }

        [TestMethod]
        public void GetReceptDetaljiByNaziv_ShouldReturnRecept()
        {
            var result = receptBusiness.GetReceptDetaljiByNaziv("Test Recept");

            
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Recept));
        }

        [TestMethod]
        public void InsertRecept_ShouldInsertNewRecept()
        {
            
            Recept recept = new Recept
            {
                Naziv = "Test Recept",
                Opis = "Test Opis",
                Komentar = "Test Komentar",
                Ocena = 5,
                Id_korisnika = 1
            };

            var result = receptBusiness.InsertRecept(recept);

            Assert.IsTrue(result > 0, $"InsertRecept should return a positive ID for a successful insert. Actual: {result}");
        }



        [TestMethod]
        public void UpdateRecept_ShouldReturnTrue()
        {
            
            Recept recept = new Recept
            {
                Id = 1, 
                Naziv = "Updated Naziv",
                Opis = "Updated Opis",
                Komentar = "Updated Komentar",
                Ocena = 4,
                Id_korisnika = 1
            };

           
            var result = receptBusiness.UpdateRecept(recept);

     
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void PretragaRecepataPoNazivu_ShouldReturnListOfRecepti()
        {
            var result = receptBusiness.PretragaRecepataPoNazivu("Test");

            
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<Recept>));
           
        }

        [TestMethod]
        public void GetAllReceptNames_ShouldReturnListOfString()
        {
            var result = receptBusiness.GetAllReceptNames();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<string>));
s        }
    }
}
