using eParking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_driven_testovi_za_zadatak_3
{
    [TestClass]
        public class DataDrivenTestLokacija
    {
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
        static IEnumerable<object[]> InvalidData
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


        /// <summary>
        /// Lokacija bi se trebala ispravno kreirati - provjera da li se u konstruktoru došlo
        /// do posljednje linije gdje se inicijalizuje kapacitet
        /// </summary>
        [TestMethod]
        [DynamicData("ValidData")]
        public void TestValidnihPodataka(string name, List<string> streets, double price, int capacity)
        {
            Lokacija lokacija = new Lokacija(name, streets, price, capacity);
            Assert.AreEqual(lokacija.Kapacitet, capacity);
        }
        /// <summary>
        /// Lokacija se ne bi trebala kreirati - treba se baciti izuzetak jer nije specificirana nijedna ulica
        /// </summary>
        [TestMethod]
        [DynamicData("InvalidData")]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestNevalidnihPodataka(string name, List<string> streets, double price, int capacity)
        {
            Lokacija lokacija = new Lokacija(name, streets, price, capacity);
        }
        /// <summary>
        /// Testira get metode
        /// </summary>
      

    }
}
