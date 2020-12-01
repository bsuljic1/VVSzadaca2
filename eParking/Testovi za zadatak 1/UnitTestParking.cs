using eParking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Testovi_za_zadatak_1
{
    
    [TestClass]
    public class UnitTestParking
    {
        static Parking parking;
        static Clan clan;
        static Lokacija lokacija1;
        static Clan clan1;
        [ClassInitialize()]
        public static void Inicijalizacija(TestContext context)
        {
            clan = new Clan(new DateTime(2022, 2, 22));
            parking = new Parking();
            lokacija1 = new Lokacija("Gorazde", new List<string> { "Nurije Rasidkadica" }, 3, 50);
            parking.RadSaLokacijom(lokacija1, 0);
            parking.DodajKorisnika(clan, true);
            clan1 = new Clan(new DateTime(2022, 2, 22));
            parking.DodajKorisnika(clan1, true);
        }

        /// <summary>
        /// Testira uspjesnu rezervaciju, kada su poslani ispravni parametri
        /// </summary>
        [TestMethod]
        public void TestUspjesneRezervacije()
        {
            clan1 = new Clan(new DateTime(2022, 2, 22));
            parking.RezervišiParking(clan1, lokacija1);
            Assert.AreEqual(clan1.RezervisanoParkingMjesto.Item2, lokacija1);
        }


        /// <summary>
        /// Testira se slucaj kada se salje kao parametar korisnik koji nije clan
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestRezervacijeKorisnikNijeClan()
        {
            Korisnik korisnik1 = new Korisnik();
            parking.RezervišiParking(korisnik1, lokacija1);
        }
        /// <summary>
        /// Testira se da li baca izuzetak kada se posalje korisnik koji vec ima rezervisano parking mjesto
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestRezervacijeKorisnikVecRezervisao()
        {
            clan.RezervišiMjesto(new Lokacija("ime", new List<string> { "ulica" }, 2, 50));
            parking.RezervišiParking(clan, lokacija1);
        }

        

    }
}

