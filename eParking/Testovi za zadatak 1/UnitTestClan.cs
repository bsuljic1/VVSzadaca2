using eParking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace Testovi_za_zadatak_1
{

    [TestClass]
    public class UnitTestClan
    {
        static Clan clan;
        static Lokacija lokacija1;
        static IEnumerable<object[]> ValidData
        {
            get
            {
                return new[]
                {
                    new object[] { "user1", "password12", "Adresa", "Automobil", "123-A-123", 5, 2022, 5, 1 },
                    new object[] { "user1", "12password", "Adresa", "Automobil", "123-A-123", 5, 2022, 5, 1 },
                    new object[] { "user1", "passworddd", "Adresa", "Automobil", "123-A-123", 5, 2022, 5, 1 },
                    new object[] { "user1", "0123456789", "Adresa", "Automobil", "123-A-123", 5, 2022, 5, 1 },
                    new object[] { "user1", "pass123word", "Adresa", "Automobil", "123-A-123", 5, 2022, 5, 1 }
                };
            }
        }
        static IEnumerable<object[]> InvalidData
        {
            get
            {
                return new[]
                {
                    new object[] { "user1", "", "Adresa", "Automobil", "123-A-123", 5, 2022, 5, 1 },
                    new object[] { "user1", "pass", "Adresa", "Automobil", "123-A-123", 5, 2022, 5, 1 },
                    new object[] { "user1", "password12/", "Adresa", "Automobil", "123-A-123", 5, 2022, 5, 1 },
                    new object[] { "user1", "123/abc/123", "Adresa", "Automobil", "123-A-123", 5, 2022, 5, 1 },
                    new object[] { "user1", " 123 123 ", "Adresa", "Automobil", "123-A-123", 5, 2022, 5, 1 }
                };
            }
        }

        [ClassInitialize()]
        public static void Inicijalizacija(TestContext context)
        {
            clan = new Clan("Lamija", "1234567891a", "lamija@etf.unsa.ba", new Vozilo("Motor", "123-E-123", 1), new DateTime(2021, 10, 10));
            List<string> listaUlica = new List<string> { "Vrbas naselje" };
            lokacija1 = new Lokacija("Bugojno", listaUlica, 2, 100);
        }

        /// <summary>
        /// Student bi se trebao ispravno kreirati - provjera da li se u konstruktoru došlo
        /// do posljednje linije gdje se status postavlja na aktivan
        /// </summary>
        [TestMethod]
        [DynamicData("ValidData")]
        public void TestValidnihPodataka(string user, string pass, string address, string vehicleType, string vehiclePlates, int vehicleNOfSeats, int endDateYear, int endDateMonth, int endDateDay)
        {
            Clan clan1 = new Clan(user, pass, address, new Vozilo(vehicleType, vehiclePlates, vehicleNOfSeats), DateTime.Now.AddYears(1));
            Assert.AreEqual(clan1.Status, Status.Aktivna);
        }
        /// <summary>
        /// Student se ne bi trebao kreirati - setter za password bi trebao bacati izuzetak
        /// </summary>
        [TestMethod]
        [DynamicData("InvalidData")]
        [ExpectedException(typeof(FormatException))]
        public void TestNevalidnihPodataka(string user, string pass, string address, string vehicleType, string vehiclePlates, int vehicleNOfSeats, int endDateYear, int endDateMonth, int endDateDay)
        {
            Clan clan1 = new Clan(user, pass, address, new Vozilo(vehicleType, vehiclePlates, vehicleNOfSeats), DateTime.Now.AddYears(1));
        }
        /// <summary>
        /// Testira get metode
        /// </summary>
        [TestMethod]
        public void TestGetMetodeClan()
        {
            String username1 = clan.Username;
            String password1 = clan.Password;
            DateTime aktivnaDo1 = clan.AktivnaDo;
            Assert.AreEqual("Lamija", username1);
            Assert.AreEqual("1234567891a", password1);
            Assert.AreEqual(new DateTime(2021, 10, 10), aktivnaDo1);
        }
        /// <summary>
        /// Testira otkazivanje rezervacije
        /// </summary>
        [TestMethod]
        public void TestOtkazivanjeRezervacije()
        {
            clan.RezervišiMjesto(lokacija1);
            Assert.IsNotNull(clan.RezervisanoParkingMjesto);
            clan.OtkažiRezervaciju();
            Assert.IsNull(clan.RezervisanoParkingMjesto);
        }
       
    }
}
