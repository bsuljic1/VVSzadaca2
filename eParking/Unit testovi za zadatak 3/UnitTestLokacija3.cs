using eParking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace Unit_testovi_za_zadatak_3
{

    [TestClass]
    public class UnitTestLokacija3
    {
        static Clan clan;
        static Lokacija lokacija1;
        [ClassInitialize()]
        public static void Inicijalizacija(TestContext context)
        {
            clan = new Clan(new DateTime(2021, 10, 25));
            lokacija1 = new Lokacija("Bugojno", new List<string> { "Voznik 5" }, 5, 20);

        }
        /// <summary>
        /// Testira metodu DajTrenutniBrojSlobodnogMjesta kada dođe do situacije kada su sva mjesta zauzeta
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestIzuzetakPriSvimZauzetimMjestima()
        {
            lokacija1.Kapacitet = 1; ///budući da će se pri pozivu metode brojač uvećati za 1
            Assert.AreEqual(1,lokacija1.DajTrenutniBrojSlobodnogMjesta()); }

        /// <summary>
        /// Testira oslobađanje zauzetog mjesta
        /// </summary>
        [TestMethod]
        public void TestOslobodiZauzetoMjesto()
        {
            Lokacija lokacija2 = new Lokacija("Sarajevo", new List<string> { "Otoka" }, 5, 150);
            lokacija2.ZauzmiMjesto(clan);
            ///budući da će se brojač++ pozvati u DajTrenutniBrojSlobodnogMjesta() pa će očekivati 2
            Assert.AreEqual(2, lokacija2.DajTrenutniBrojSlobodnogMjesta());
            lokacija2.OslobodiMjesto();
            ///brojač će ostati na istom budući da se oduzelo pa dodalo mjesto
            Assert.AreEqual(2, lokacija2.DajTrenutniBrojSlobodnogMjesta());
        }

        /// <summary>
        /// Testira get metode
        /// </summary>
        [TestMethod]
        public void TestGetMetodeLokacija()
        {
            lokacija1.Naziv = "Bugojno";
            String naziv1 = lokacija1.Naziv;
            List<string> ulice1 = lokacija1.Ulice;
            lokacija1.Cijena = 5;
            double cijena1 = lokacija1.Cijena;
            lokacija1.Kapacitet = 10;
            int kapacitet1 = lokacija1.Kapacitet;
            Assert.AreEqual("Bugojno", naziv1);
            Assert.AreEqual(1, ulice1.Count);
            Assert.AreEqual(5, cijena1);
            Assert.AreEqual(10, kapacitet1);

        }
        /// <summary>
        /// Testira neispravan format naziva
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNeispravanFormatNaziva()
        {
            lokacija1.Naziv = " "; }
        /// <summary>
        /// Testira neispravan format cijene
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNeispravanFormatCijene()
        {
            lokacija1.Cijena = 49.00;
            Assert.AreEqual(49.00, lokacija1.Cijena);
            lokacija1.Cijena = -1; }
        /// <summary>
        /// Testira neispravan format kapaciteta
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNeispravanFormatKapaciteta()
        {
            lokacija1.Kapacitet = 0;
            Assert.AreEqual(0, lokacija1.Kapacitet);
            lokacija1.Kapacitet = -1;
        }
        /// <summary>
        /// Testira kontruktor kada se pošalje null za ulice
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestKonstruktorSaIzuzetkom()
        {
            Lokacija l = new Lokacija("Zagreb", null, 10, 1000);
        }

    }
}


