using eParking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace Unit_testovi_za_zadatak_3
{

    [TestClass]
    public class UnitTestVozilo
    {
        static Vozilo vozilo;
        static IEnumerable<object[]> ValidData
        {
            get
            {
                return new[]
                {
                    new object[] { "Automobil", "058-A-585", 5},
                    new object[] { "Autobus", "056-K-565", 30},
                    new object[] { "Kamionet", "055-O-555", 3},
                    new object[] { "Motor", "666-A-666", 1},
                };
            }
        }
        static IEnumerable<object[]> InvalidData1
        {
            get
            {
                return new[]
                {
                   new object[] { "Automobil", "A58A585", 5},
                    new object[] { "Autobus", "K56K565", 30},
                    new object[] { "Kamionet", "O55-O-555", -1},
                    new object[] { "Motor", "6-6-A-6kk", 1},
                };
            }
        }

        static IEnumerable<object[]> InvalidData2
        {
            get
            {
                return new[]
                {
                     new object[] { "auto", "A58-A-585", 5},
                    new object[] { "autobus", "K56-K-565", 30},
                    new object[] { "kamion", "O55-O-555", 3},
                    new object[] { "motor", "666-A-666", 1},
                };
            }
        }


        /// <summary>
        /// Vozilo bi se trebalo ispravno kreirati - provjera da li se u konstruktoru došlo
        /// do posljednje linije gdje se postavlja broj sjedista
        /// </summary>
        [TestMethod]
        [DynamicData("ValidData")]
        public void TestValidnihPodataka(string type, string plates, int noSeats)
        {
            Vozilo vozilo = new Vozilo(type, plates, noSeats);
            Assert.AreEqual(vozilo.BrojSjedišta, noSeats);
        }
        /// <summary>
        /// Vozilo se ne bi trebalo kreirati - setter za tablice i setter za broj sjedista treba baciti izuzetak
        /// </summary>
        [TestMethod]
        [DynamicData("InvalidData1")]
        [ExpectedException(typeof(FormatException))]
        public void TestNevalidnihPodataka1(string type, string plates, int noSeats)
        {
            Vozilo vozilo = new Vozilo(type, plates, noSeats);
        }

        /// <summary>
        /// Vozilo se ne bi trebalo kreirati - setter za tablice i setter za broj sjedista treba baciti izuzetak
        /// </summary>
        [TestMethod]
        [DynamicData("InvalidData2")]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNevalidnihPodataka2(string type, string plates, int noSeats)
        {
            Vozilo vozilo = new Vozilo(type, plates, noSeats);
        }

        [ClassInitialize()]
        public static void Inicijalizacija(TestContext context)
        {
            vozilo = new Vozilo("Automobil", "123-E-123", 5);
        }
        /// <summary>
        /// Testira neispravan format tablica 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestNeispravanFormatTablica()
        {
            vozilo.Tablice = "1234-e-1";
        }
        /// <summary>
        /// Testira nepostojeću vrstu vozila
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNepostojećaVrstaVozila()
        {
            vozilo.Vrsta = "Avion";
        }
        /// <summary>
        /// Testira neispravan format sjedišta
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestNeispravanFormatSjedišta()
        {
            vozilo.BrojSjedišta = -1;
        }
        /// <summary>
        /// Testira get metode
        /// </summary>
        [TestMethod]
        public void TestGetMetode()
        {
            string vrsta1 = vozilo.Vrsta;
            string tablice1 = vozilo.Tablice;
            int brojSjedišta1 = vozilo.BrojSjedišta;
            Vozilo novoVozilo = new Vozilo(vrsta1, tablice1, brojSjedišta1);
            Assert.AreEqual(vrsta1, novoVozilo.Vrsta);
            Assert.AreEqual(tablice1, novoVozilo.Tablice);
            Assert.AreEqual(brojSjedišta1, novoVozilo.BrojSjedišta);

        }

    }
}