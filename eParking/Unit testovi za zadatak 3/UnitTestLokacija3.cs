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

        static IEnumerable<object[]> ValidData
        {
            get
            {
                return new[]
                {
                    new object[] { "ime", new List<string> { "Voznik 2"}, 2, 50},
                    new object[] { "gorazde", new List<string> { "Trg Branilaca bb"}, 3, 30},
                    new object[] { "travnik", new List<string> { "Bosanska bb"}, 1, 100},
                    new object[] { "sarajevo", new List<string> { "Ferhadija bb"}, 2, 50}
                };
            }
        }
        static IEnumerable<object[]> InvalidData1
        {
            get
            {
                return new[]
                {
                     new object[] { "ime", null, 2, 50},
                    new object[] { "gorazde", null, 3, 30},
                    new object[] { "travnik", null, 1, 100},
                    new object[] { "sarajevo", null, 2, 50}
                };
            }
        }

        static IEnumerable<object[]> InvalidData2
        {
            get
            {
                return new[]
                {
                    new object[] { "", new List<string> { "Voznik 2"}, 2, 50},
                    new object[] { "gorazde", new List<string> { "Trg Branilaca bb"}, -30, 30},
                    new object[] { "travnik", new List<string> { "Bosanska bb"}, 100, 100},
                    new object[] { "sarajevo", new List<string> { "Ferhadija bb"}, 2, -5}
                };
            }
        }


        [ClassInitialize()]
        public static void Inicijalizacija(TestContext context)
        {
            clan = new Clan(new DateTime(2021, 10, 25));
            lokacija1 = new Lokacija("Bugojno", new List<string> { "Voznik 5" }, 5, 20);

        }

        /// <summary>
        /// Lokacija bi se trebala ispravno kreirati - provjera da li se u konstruktoru došlo
        /// do posljednje linije gdje se inicijalizuje kapacitet
        /// </summary>
        [TestMethod]
        [DynamicData("ValidData")]
        public void TestValidnihPodatakaLokacija1(string name, List<string> streets, double price, int capacity)
        {
            Lokacija lokacija = new Lokacija(name, streets, price, capacity);
            Assert.AreEqual(lokacija.Kapacitet, capacity);
        }
        /// <summary>
        /// Lokacija se ne bi trebala kreirati - treba se baciti izuzetak jer nije specificirana nijedna ulica
        /// </summary>
        [TestMethod]
        [DynamicData("InvalidData1")]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestNevalidnihPodatakaLokacija(string name, List<string> streets, double price, int capacity)
        {
            Lokacija lokacija = new Lokacija(name, streets, price, capacity);
        }

        /// <summary>
        /// Lokacija se ne bi trebala kreirati - setteri za cijenu, kapacitet i naziv trebaju baciti ArgumentException
        /// </summary>
        [TestMethod]
        [DynamicData("InvalidData2")]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNevalidnihPodatakaLokacija2(string name, List<string> streets, double price, int capacity)
        {
            Lokacija lokacija = new Lokacija(name, streets, price, capacity);
        }



        /// <summary>
        /// Testira metodu DajTrenutniBrojSlobodnogMjesta kada dođe do situacije kada su sva mjesta zauzeta
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestIzuzetakPriSvimZauzetimMjestima()
        {
            lokacija1.Kapacitet = 1; ///budući da će se pri pozivu metode brojač uvećati za 1
            Assert.AreEqual(1,lokacija1.DajTrenutniBrojSlobodnogMjesta()); 
        }

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


