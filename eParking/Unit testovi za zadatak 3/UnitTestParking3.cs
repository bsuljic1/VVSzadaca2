using eParking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Unit_testovi_za_zadatak_3
{

    [TestClass]
    public class UnitTestParking3
    {
        static Parking parking;
        static Clan clan;
        static Lokacija lokacija1;


        [ClassInitialize()]
        public static void Inicijalizacija(TestContext context)
        {
            clan = new Clan(new DateTime(2022, 2, 22));
            parking = new Parking();
            lokacija1 = new Lokacija("Gorazde", new List<string> { "Nurije Rasidkadica" }, 3, 50);
            parking.RadSaLokacijom(lokacija1, 0);
            parking.DodajKorisnika(clan, true);

        }

        /// <summary>
        /// Testira dodavanje korisnika koji nije član
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDodavanjeKorisnikaKojiNijeČlan()
        {
            parking.DodajKorisnika(clan, false);
        }
        /// <summary>
        /// Testira odabir opcije 1 kod rada sa lokacijom pri čemu se u drugom pozivu ne nalazi taj naziv dodan u lokacije
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestRadSaLokacijomOpcija0()
        {
            Lokacija lokacija3 = new Lokacija("Bugojno", new List<string> { "Voznik 2" }, 3, 70);
            int brojac = parking.Lokacije.Count;
            parking.RadSaLokacijom(lokacija3, 0);
            Assert.AreEqual(brojac + 1, parking.Lokacije.Count);
            Lokacija lokacija2 = new Lokacija("DonjiVakuf", new List<string> { "Saracev Sokak" }, 3, 70);
            parking.Lokacije.Add(lokacija2);
            parking.RadSaLokacijom(lokacija2, 0);

        }
        /// <summary>
        /// Testira odabir opcije 1 kod rada sa lokacijom pri čemu se u drugom pozivu ne nalazi taj naziv dodan u lokacije
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestRadSaLokacijomOpcija1()
        {
            Lokacija lokacija3 = new Lokacija("Gorazde", new List<string> { "Nurije Rasidkadica 4" }, 3, 70);
            parking.RadSaLokacijom(lokacija3, 1);
            Lokacija lokacija2 = new Lokacija("Mostar", new List<string> { "Stari Most 1" }, 3, 100);
            parking.RadSaLokacijom(lokacija2, 1);   
        }
        /// <summary>
        /// Testira odabir opcije 2 kod rada sa lokacijom pri čemu u drugom pozivu se ne nalazi taj naziv dodan u lokacije
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestRadSaLokacijomOpcija2()
        {
            Lokacija lokacija3 = new Lokacija("Gorazde", new List<string> { "Nurije Rasidkadica 4", "Nurije Rasidkadica 5" }, 3, 70);
            parking.Lokacije.Add(lokacija3);
            parking.RadSaLokacijom(lokacija3, 2, new List<string>{ "Voznik 2", "Voznik 6"});
            Lokacija lokacija2 = new Lokacija("Bihać", new List<string> { "Unska 1" }, 3, 100);
            parking.RadSaLokacijom(lokacija2, 2);
        }
        /// <summary>
        /// Testira neuspjesnu rezervaciju, kada su sva mjesta zauzeta
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestNeuspjesneRezervacije()
        {
            Clan clan1 = new Clan(new DateTime(2022, 2, 22));
            Lokacija lokacija2 = new Lokacija("Gorazde", new List<string> { "Nurije Rasidkadica 4", "Nurije Rasidkadica 5" }, 3, 1);
            parking.RezervišiParking(clan1, lokacija2);
        }
        /// <summary>
        /// Testira se da li baca izuzetak kada lokacija nema nijedne ulice
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestLokacijaBezUlice()
        {
            Lokacija novaLokacija = new Lokacija("Bugojno", new List<string> { "Lamele" }, 3, 70);
            Clan noviClan = new Clan(new DateTime(2020, 12, 12));
            parking.DodajKorisnika(noviClan, true);
            parking.RezervišiParking(noviClan, novaLokacija);
            novaLokacija.Ulice.Clear();
            parking.Lokacije.Add(novaLokacija);
            parking.IzračunajTrenutnuZaradu();

        }
        /// <summary>
        /// Testira se validna metoda racunanja zarade
        /// </summary>
        [TestMethod]
        public void TestProracunTrenutneZarade()
        {
            Lokacija novaLokacija1 = new Lokacija("Bugojno", new List<string> { "Lamele" }, 1, 70);
            Lokacija novaLokacija2 = new Lokacija("Travnik", new List<string> { "Kalibunar 1" },1, 70);
            Lokacija novaLokacija3 = new Lokacija("Goražde", new List<string> { "ulica"}, 1, 70);

            Clan noviClan1 = new Clan(new DateTime(2020, 12, 12));
            parking.DodajKorisnika(noviClan1, true);
            Clan noviClan2 = new Clan(new DateTime(2020, 12, 12));
            parking.DodajKorisnika(noviClan2, true);
            Clan noviClan3 = new Clan(new DateTime(2020, 12, 12));
            parking.DodajKorisnika(noviClan3, true);
            parking.RezervišiParking(noviClan1, novaLokacija1);
            parking.RezervišiParking(noviClan2, novaLokacija2);
            parking.RezervišiParking(noviClan3, novaLokacija3);
            parking.Lokacije.Add(novaLokacija1);
            parking.Lokacije.Add(novaLokacija2);
            parking.Lokacije.Add(novaLokacija3);
            Assert.AreEqual(1.0, parking.IzračunajTrenutnuZaradu());
        }
        }
}


