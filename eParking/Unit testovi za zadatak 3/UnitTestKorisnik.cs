using eParking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace Unit_testovi_za_zadatak_3
{

    [TestClass]
    public class UnitTestKorisnik
    {
        static Korisnik korisnik;
        [ClassInitialize()]
        public static void Inicijalizacija(TestContext context)
        {
            korisnik = new Korisnik("Armin", "Donjići", new Vozilo("Automobil", "123-E-123", 5));
            korisnik.UlogujSe();

        }
        /// <summary>
        /// Testira get metode
        /// </summary>
        [TestMethod]
        public void TestGetMetodeKorisnik()
        {
         
            int brojLogovanja = korisnik.BrojLogovanja;
            String adresa = korisnik.Adresa;
            Vozilo vozilo = korisnik.Vozilo;
            Assert.AreEqual(1, brojLogovanja);
            Assert.AreEqual("Donjići", adresa);
            Assert.IsNotNull(vozilo);
        }
        /// <summary>
        /// Testira neispravno korisničko ime
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestNeispravnoKorisničkoIme()
        {
            korisnik.Username = "Arma";
        }

        /// <summary>
        /// Testira neispravnu adresu
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestNeispravnaAdresa()
        {
            korisnik.Adresa = "   ";
        }

    }

}