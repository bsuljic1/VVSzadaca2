using eParking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Xunit.Sdk;

namespace Testovi_za_zadatak_1
{
    //Amina Šiljak
    [TestClass]
    public class UnitTestClanRezervacija
    {
        static Lokacija l;
        [ClassInitialize()]
        public static void Inicijalizacija(TestContext context)
        {
            List<string> listaUlica = new List<string> { "Bosanska bb" };
            l = new Lokacija("Travnik", listaUlica, 2, 100);
        }
        /// <summary>
        /// Testira se rezervacija sa isteklom clanarinom
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestRezervacijeSaIsteklomClanarinom()
        {
            Clan clan = new Clan(DateTime.Now); //postavlja istek clanarine na ovaj trenutak
            clan.RezervišiMjesto(l); 
        }
        /// <summary>
        /// Testira se uspjesna rezervacija 
        /// </summary>
        [TestMethod]
        public void TestUspjesneRezervacije()
        {
            Clan c = new Clan(new DateTime(2021, 12, 25));
            c.RezervišiMjesto(l);
            Assert.AreEqual(c.RezervisanoParkingMjesto.Item2, l);
        }
        /// <summary>
        /// Testira se rezervacija istog clana dva puta
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestPonovneRezervacije()
        {
            Clan c = new Clan(new DateTime(2021, 12, 25));
            c.RezervišiMjesto(l);
            c.RezervišiMjesto(l); 
        }
    }
}
