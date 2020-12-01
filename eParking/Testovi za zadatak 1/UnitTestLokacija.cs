using eParking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace Testovi_za_zadatak_1
{

    [TestClass]
    public class UnitTestLokacija
    {
        static Clan clan;
        static Lokacija lokacija1;
        [ClassInitialize()]
        public static void Inicijalizacija(TestContext context)
        {
            clan = new Clan(new DateTime(2021, 10, 25));
            lokacija1 = new Lokacija("Bugojno", new List<string> { "Voznik 2" }, 5, 30);

        }
        /// <summary>
        /// Testira uspješno zauzimanje slobodnog mjesta
        /// </summary>
        [TestMethod]
        public void TestUspješnaRezervacija()
        {
            Lokacija lokacija2 = new Lokacija("Bugojno", new List<string> { "Nugle" }, 5, 50);
            lokacija2.ZauzmiMjesto(clan);
            ///budući da će se brojač++ pozvati u DajTrenutniBrojSlobodnogMjesta() pa će očekivati 2
            Assert.AreEqual(2, lokacija2.DajTrenutniBrojSlobodnogMjesta());
        }

        /// <summary>
        /// Testira rezervirsanje parking mjesta klijentu kojem je istekla članarina
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestRezervacijaParkingaSaIsteklomČlanarinom()
        {
            Clan clan2 = new Clan(DateTime.Now);
            lokacija1.ZauzmiMjesto(clan2);
        }
        /// <summary>
        /// Testira rezervirsanje parking mjesta ukoliko su sva mjesta na datoj lokaciji zauzeta
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestRezervacijaParkingaSaZauzetimMjestima()
        {
            lokacija1.Kapacitet = 0;
            lokacija1.ZauzmiMjesto(clan);
         }
    }
}



