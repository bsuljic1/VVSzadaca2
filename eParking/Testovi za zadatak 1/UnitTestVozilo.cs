using eParking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace Testovi_za_zadatak_1
{

    [TestClass]
    public class UnitTestVozilo
    {
        static Vozilo vozilo;
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