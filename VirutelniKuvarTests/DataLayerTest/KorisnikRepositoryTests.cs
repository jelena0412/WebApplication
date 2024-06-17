using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer;
using DataLayer.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System;

namespace DataLayer.Tests
{
    [TestClass]
    public class KorisnikRepositoryTests
    {
        private Korisnik korisnik;
        private KorisnikRepository korisnikRepository;

        [TestInitialize]
        public void Init()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString;
            Console.WriteLine("Loaded connection string: " + (connectionString ?? "null"));

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                Assert.Fail("Connection string 'DefaultConnection' is not set in the configuration file.");
            }

            try
            {
                korisnikRepository = new KorisnikRepository();
            }
            catch (Exception ex)
            {
                Assert.Fail($"Failed to initialize KorisnikRepository. Exception: {ex.Message}");
            }

            korisnik = new Korisnik
            {
                ime = "Test",
                prezime = "Korisnik",
                korisnicko_ime = "test.korisnik",
                mejl = "test@example.com",
                broj_telefona = "123456789",
                lozinka = "test123"
            };
        }


        [TestCleanup]
        public void Clean()
        {
            if (korisnikRepository == null)
            {
                Assert.Fail("KorisnikRepository instance is null. Cannot clean up the test data.");
            }

            List<Korisnik> korisnici = null;

            try
            {
                korisnici = korisnikRepository.GetAllUsers()?.Where(x => x.ime == korisnik.ime).ToList();
            }
            catch (Exception ex)
            {
                Assert.Fail($"Failed to get users for cleanup. Exception: {ex.Message}");
            }

            if (korisnici != null)
            {
                foreach (var k in korisnici)
                {
                    try
                    {
                        korisnikRepository.DeleteUser(k.id);
                    }
                    catch (Exception ex)
                    {
                        Assert.Fail($"Failed to delete user during cleanup. Exception: {ex.Message}");
                    }
                }
            }
        }

        [TestMethod]
        public void GetAllUsersTest()
        {
            
            korisnikRepository.InsertUser(korisnik);

            
            List<Korisnik> korisnici = null;

            try
            {
                korisnici = korisnikRepository.GetAllUsers();
            }
            catch (Exception ex)
            {
                Assert.Fail($"Failed to get all users. Exception: {ex.Message}");
            }

           
            Assert.IsNotNull(korisnici);
            Assert.IsTrue(korisnici.Count > 0);
        }

        [TestMethod]
        public void InsertUserTest()
        {
           
            int affectedRows = 0;

            try
            {
                affectedRows = korisnikRepository.InsertUser(korisnik);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Failed to insert user. Exception: {ex.Message}");
            }

         
            Assert.AreEqual(1, affectedRows);
        }

        [TestMethod]
        public void UpdateUserTest()
        {
           
            korisnikRepository.InsertUser(korisnik);
            Korisnik updatedKorisnik = null;

            try
            {
                updatedKorisnik = korisnikRepository.GetAllUsers().FirstOrDefault(x => x.ime == korisnik.ime);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Failed to get user for update. Exception: {ex.Message}");
            }

            if (updatedKorisnik != null)
            {
                updatedKorisnik.ime = "UpdatedIme";

                
                int result = 0;

                try
                {
                    result = korisnikRepository.UpdateUser(updatedKorisnik);
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Failed to update user. Exception: {ex.Message}");
                }

           
                Assert.AreEqual(1, result);
            }
            else
            {
                Assert.Fail("User to update not found.");
            }
        }

        [TestMethod]
        public void DeleteUserTest()
        {
            
            korisnikRepository.InsertUser(korisnik);
            List<Korisnik> korisnici = null;

            try
            {
                korisnici = korisnikRepository.GetAllUsers().Where(x => x.ime == korisnik.ime).ToList();
            }
            catch (Exception ex)
            {
                Assert.Fail($"Failed to get users for deletion. Exception: {ex.Message}");
            }

            if (korisnici.Any())
            {
                Korisnik deletedKorisnik = korisnici[0];

                
                int result = 0;

                try
                {
                    result = korisnikRepository.DeleteUser(deletedKorisnik.id);
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Failed to delete user. Exception: {ex.Message}");
                }

            
                Assert.AreEqual(1, result);
            }
            else
            {
                Assert.Fail("User to delete not found.");
            }
        }

        [TestMethod]
        public void ProveriKorisnikaTest()
        {
            
            try
            {
                korisnikRepository.InsertUser(korisnik);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Failed to insert user for checking. Exception: {ex.Message}");
            }

          
            bool korisnikPostoji = false;

            try
            {
                korisnikPostoji = korisnikRepository.ProveriKorisnika(korisnik.korisnicko_ime, korisnik.lozinka);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Failed to check user existence. Exception: {ex.Message}");
            }

           
            Assert.IsTrue(korisnikPostoji);
        }
    }
}
