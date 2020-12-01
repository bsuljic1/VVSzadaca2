using eParking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Unit_testovi_za_zadatak_3
{

    [TestClass]
    public class UnitTestKorisnik
    {
        static Korisnik korisnik;

        static IEnumerable<object[]> ValidData
        {
            get
            {
                return new[]
                {
                    new object[] { "user1", "Adresa1", "Automobil", "123-A-123", 5},
                    new object[] { "user2", "Adresa2", "Autobus", "123-A-123", 50},
                    new object[] { "user3", "Adresa3", "Automobil", "123-A-123", 4},
                    new object[] { "user4", "Adresa4", "Motor", "123-A-123", 1},
                    new object[] { "user5", "Adresa5", "Kamionet", "123-A-123", 3 }
                };
            }
        }
        static IEnumerable<object[]> InvalidData
        {
            get
            {
                return new[]
                {
                    new object[] { "", "Adresa1", "Automobil", "123-A-123", 5},
                    new object[] { "user2", "", "Autobus", "123-A-123", 50},
                    new object[] { null, "Adresa3", "Automobil", "123-A-123", 4},
                    new object[] { "user4", null, "Motor", "123-A-123", 1},
                    new object[] { "u", "Adresa5", "Kamionet", "123-A-123", 3 }
                };
            }
        }

        /// <summary>
        /// Korisnik bi se trebao ispravno kreirati - provjera da li se u konstruktoru došlo
        /// do posljednje linije gdje se postavlja vozilo
        /// </summary>
        [TestMethod]
        [DynamicData("ValidData")]
        public void TestValidnihPodataka(string user, string address, string vehicleType, string vehiclePlates, int vehicleNOfSeats)
        {
            Korisnik k = new Korisnik(user, address, new Vozilo(vehicleType, vehiclePlates, vehicleNOfSeats));
            Assert.AreEqual(k.Vozilo.BrojSjedišta, vehicleNOfSeats);
        }
        /// <summary>
        /// Korisnik se ne bi trebao kreirati - setter za username, adress baca izuzetak
        /// </summary>
        [TestMethod]
        [DynamicData("InvalidData")]
        [ExpectedException(typeof(FormatException))]
        public void TestNevalidnihPodataka(string user, string address, string vehicleType, string vehiclePlates, int vehicleNOfSeats)
        {
            Korisnik k = new Korisnik(user, address, new Vozilo(vehicleType, vehiclePlates, vehicleNOfSeats));
        }


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