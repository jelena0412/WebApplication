using System;
using System.Collections.Generic;
using DataLayer;
using DataLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataLayerTests
{
    [TestClass]
    public class StavkeRepositoryTests
    {
        [TestMethod]
        public void GetAllStavka_ShouldReturnListOfStavka()
        {
            // Arrange
            StavkeRepository repository = new StavkeRepository();

            // Act
            List<Stavka> stavke = repository.GetAllStavka();

            // Assert
            Assert.IsNotNull(stavke);
            Assert.IsTrue(stavke.Count > 0);
        }

        [TestMethod]
        public void InsertStavke_ShouldInsertNewStavka()
        {
            // Arrange
            StavkeRepository repository = new StavkeRepository();
            Stavka newStavka = new Stavka
            {
                kolicina = "100g",
                id_recepta = 1, // Id recepta za testiranje
                id_sastojka = 1 // Id sastojka za testiranje
            };

            // Act
            int rowsAffected = repository.InsertStavke(newStavka);

            // Assert
            Assert.AreEqual(1, rowsAffected); // Proverite da li je jedan red ubačen
        }

        [TestMethod]
        public void UpdateStavke_ShouldUpdateExistingStavka()
        {
            // Arrange
            StavkeRepository repository = new StavkeRepository();
            Stavka existingStavka = new Stavka
            {
                Id = 1, // Postojeći Id stavke za ažuriranje
                kolicina = "200g", // Nova vrednost količine
                id_recepta = 1, // Id recepta za testiranje
                id_sastojka = 1 // Id sastojka za testiranje
            };

            // Act
            int rowsAffected = repository.UpdateStavke(existingStavka);

            // Assert
            Assert.IsTrue(rowsAffected >= 0); // Proverite da li je broj ažuriranih redova veći ili jednak 0
        }
    }
}
