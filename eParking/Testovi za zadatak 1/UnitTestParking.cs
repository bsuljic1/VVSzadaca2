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
        [TestInitialize()]
        public static void Inicijalizacija(TestContext context)
        {
            parking = new Parking();
            List<string> listaUlica = new List<string> { "Nurije Rasidkadica" };
            Lokacija lokacija1 = new Lokacija("Gorazde", listaUlica, 3, 50);
            parking.RadSaLokacijom(lokacija1, 0);

            Korisnik korisnik = new Korisnik();
            parking.DodajKorisnika(korisnik, true);
        }

        /// <summary>
        /// Testira uspjesnu rezervaciju, kada su poslani ispravni parametri
        /// </summary>
        [TestMethod]
        public void TestUspjesneRezervacije()
        {
            Clan c = (Clan)parking.Korisnici[0];
            Lokacija l = parking.Lokacije[0];
            parking.RezervišiParking(c, l);
            Assert.AreEqual(c.RezervisanoParkingMjesto.Item2, l);
        }


        /// <summary>
        /// Testira se slucaj kada se salje kao parametar korisnik koji nije clan
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestRezervacijeKorisnikNijeClan()
        {
            Korisnik korisnik = new Korisnik();
            Lokacija l = parking.Lokacije[0];
            parking.RezervišiParking(korisnik, l);
        }

        /// <summary>
        /// Testira se da li baca izuzetak kada se posalje korisnik koji vec ima rezervisano parking mjesto
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestRezervacijeKorisnikVecRezervisao()
        {
            Clan c = (Clan)parking.Korisnici[0];
            c.RezervišiMjesto(new Lokacija("ime", new List<string> { "ulica" }, 2, 50));
            Lokacija l = parking.Lokacije[0];
            parking.RezervišiParking(c, l);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestRezervacijeLokacijaZauzeta()
        {
            Clan c = (Clan)parking.Korisnici[0];
            Lokacija l = parking.Lokacije[0];
            l.Kapacitet = 0;
            parking.RezervišiParking(c, l);
        }
    }
}

