using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clan;
using Lokacija;
using Korisnik;

namespace Testovi_za_zadatak_1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLogovanjaKorisnikaStoPuta()
        {
            Korisnik k = new Korisnik();
            for (int i = 0; i < 99; i++) k.UlogujSe();
            Assert.AreEqual(k.UlogujSe(), false);
        }
    }
}
