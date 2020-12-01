using eParking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace Testovi_za_zadatak_1
{

    [TestClass]
    public class UnitTestTransakcija
    {
        static Vozilo vozilo;
        Transakcija transakcija = new Transakcija();
        [ClassInitialize()]
        public static void Inicijalizacija(TestContext context)
        {
            vozilo = new Vozilo("Motor", "123-E-123", 1);
           

        }
        /// <summary>
        /// Testira bacanje izuzetka prilikom poziva metoda koja nije implementirana
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void TestDajVrijemeDolaskaIzuzetak()
        { 
            transakcija.DajVrijemeDolaska(vozilo);
        }

    }
        
}
