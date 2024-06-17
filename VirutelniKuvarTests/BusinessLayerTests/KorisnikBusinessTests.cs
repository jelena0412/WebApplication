using System;
using System.Collections.Generic;
using BusinessLayer;
using DataLayer;
using DataLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLayerTests
{
    [TestClass]
    public class KorisnikBusinessTests
    {
        [TestMethod]
        public void Prijava_ShouldReturnTrueIfCredentialsMatch()
        {
            
            var mockRepository = new MockKorisnikRepository();
            var korisnikBusiness = new KorisnikBusiness(mockRepository);
            string validUsername = "testUser";
            string validPassword = "testPassword";

            bool result = korisnikBusiness.Prijava(validUsername, validPassword);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Prijava_ShouldReturnFalseIfCredentialsDoNotMatch()
        {
            var mockRepository = new MockKorisnikRepository();
            var korisnikBusiness = new KorisnikBusiness(mockRepository);
            string invalidUsername = "invalidUser";
            string invalidPassword = "invalidPassword";

            bool result = korisnikBusiness.Prijava(invalidUsername, invalidPassword);

            
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetAllUsers_ShouldReturnListOfUsers()
        {
            var mockRepository = new MockKorisnikRepository();
            var korisnikBusiness = new KorisnikBusiness(mockRepository);

            
            List<Korisnik> users = korisnikBusiness.GetAllUsers();

            Assert.IsNotNull(users);
            Assert.IsTrue(users.Count > 0);
        }

    }

    
    class MockKorisnikRepository : KorisnikRepository
    {
        public override List<Korisnik> GetAllUsers()
        {
           
            return new List<Korisnik>
            {
                new Korisnik { id = 1, korisnicko_ime = "testUser", lozinka = "testPassword" },
                new Korisnik { id = 2, korisnicko_ime = "anotherUser", lozinka = "anotherPassword" }
            };
        }

        
    }
}
