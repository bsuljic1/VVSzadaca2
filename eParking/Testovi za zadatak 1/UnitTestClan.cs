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
        [ClassInitialize()]
        public static void Inicijalizacija(TestContext context)
        {
            clan = new Clan("Lamija", "1234567891a", "lamija@etf.unsa.ba", new Vozilo("Motor", "123-E-123", 1), new DateTime(2021, 10, 10));
            List<string> listaUlica = new List<string> { "Vrbas naselje" };
            lokacija1 = new Lokacija("Bugojno", listaUlica, 2, 100);
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
        /// Testira neispravan format passworda i seter
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestNeispravanFormat()
        {
            Clan clan1 = new Clan("Lamija", "1a2a1a1a1a1a1", "lamija@etf.unsa.ba", new Vozilo("Motor", "123-E-123", 1), new DateTime(2021, 10, 10));
                clan1.Password = "123a";   
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
