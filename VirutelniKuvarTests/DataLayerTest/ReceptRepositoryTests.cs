using DataLayer;
using DataLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DataLayerTests
{
    [TestClass]
    public class ReceptRepositoryTests
    {
        [TestMethod]
        public void GetAllRecepti_ShouldReturnListOfRecepti()
        {
           
            ReceptRepository repository = new ReceptRepository();

            
            List<Recept> recepti = repository.GetAllRecepti();

          
            Assert.IsNotNull(recepti);
            Assert.IsTrue(recepti.Count > 0);
        }

        [TestMethod]
        public void InsertRecept_ShouldInsertNewRecept()
        {
           
            ReceptRepository repository = new ReceptRepository();
            Recept newRecept = new Recept
            {
                Naziv = "Test recept",
                Opis = "Opis test recepta",
                Komentar = "Komentar test recepta",
                Ocena = 5,
                Id_korisnika = 1 
            };

            
            int rowsAffected = repository.InsertRecept(newRecept);

          
            Assert.AreEqual(1, rowsAffected); 
        }

        [TestMethod]
        public void UnesiReceptSaSastojcimaStavkama_ShouldInsertNewReceptWithIngredientsAndItems()
        {
          
            ReceptRepository repository = new ReceptRepository();
            Recept newRecept = new Recept
            {
                Naziv = "Test recept sa sastojcima i stavkama",
                Opis = "Opis test recepta sa sastojcima i stavkama",
                Komentar = "Komentar test recepta sa sastojcima i stavkama",
                Ocena = 5,
                Id_korisnika = 1 
            };

            List<Sastojak> sastojci = new List<Sastojak>
            {
                new Sastojak { naziv_sastojka = "Test sastojak 1", mera = "gram" },
                new Sastojak { naziv_sastojka = "Test sastojak 2", mera = "komad" }
            };

            List<Stavka> stavke = new List<Stavka>
{
    new Stavka { kolicina = "100" }, 
    new Stavka { kolicina = "2" }     
};

          
            bool success = repository.UnesiReceptSaSastojcimaStavkama(newRecept, sastojci, stavke);

         
            Assert.IsTrue(success);
        }

        [TestMethod]
public void UpdateRecept()
{
    
    ReceptRepository repository = new ReceptRepository();
    Recept existingRecept = new Recept
    {
        Id = 1, 
        Naziv = "Ažurirani naziv",
        Opis = "Ažurirani opis",
        Komentar = "Ažurirani komentar",
        Ocena = 4,
        Id_korisnika = 1 
    };


    int rowsAffected = repository.UpdateRecept(existingRecept);

  
    Assert.IsTrue(rowsAffected >= 0); 
}

      

        [TestMethod]
        public void GetReceptByNaziv_ShouldReturnListOfReceptiMatchingNaziv()
        {
            
            ReceptRepository repository = new ReceptRepository();
            string naziv = "TestNaziv"; 

           
            List<Recept> recepti = repository.GetReceptByNaziv(naziv);

            
            Assert.IsNotNull(recepti);
            Assert.IsTrue(recepti.Count > 0);
           
        }
    }
}
