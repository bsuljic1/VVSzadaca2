using eParking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Testovi_za_zadatak_1
{
    //Amina Šiljak
    [TestClass]
    public class UnitTest2
    {
        static Lokacija l;
        [ClassInitialize()]
        public static void Inicijalizacija(TestContext context)
        {
            List<string> listaUlica = new List<string> { "Bosanska bb" };
            l = new Lokacija("Travnik", listaUlica, 2, 100);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestRezervacijeSaIsteklomClanarinom()
        {
            Clan clan = new Clan(DateTime.Now); //postavlja istek clanarine na trenutni momenat
            clan.RezervišiMjesto(l);
        }
        [TestMethod]
        public void TestUspjesneRezervacije()
        {
            Clan c = new Clan(new DateTime(2021, 12, 25));
            c.RezervišiMjesto(l);
            Assert.AreEqual(c.RezervisanoParkingMjesto.Item2, l);
        }
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
