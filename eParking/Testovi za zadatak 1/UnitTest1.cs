using eParking;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testovi_za_zadatak_1
{
    //Amina Šiljak
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestUpjesnogLogovanjaPrviPut()
        {
            Korisnik k = new Korisnik();
            Assert.AreEqual(k.UlogujSe(), true);
        }
        [TestMethod]
        public void TestNeuspjesnogLogovanja()
        {
            Korisnik k = new Korisnik();
            for (int i = 0; i < 100; i++) k.UlogujSe();
            Assert.AreEqual(k.UlogujSe(), false);
        }
    }
}
