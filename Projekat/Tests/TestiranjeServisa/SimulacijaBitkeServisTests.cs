using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using Domain.Modeli;
using Domain.Repositories.HerojiRepository;
using Domain.Repositories.TimoviRepository;
using Domain.Repositories.MapeRepository;
using Services.BitkaServisi;
using Services.ProdavnicaServisi;
using Domain.Servisi;

namespace Tests
{
    [TestFixture]
    public class SimulacijaBitkeServisTests
    {
        private Mock<IHerojiRepository> mockHeroji;
        private Mock<ITimoviRepository> mockTimovi;
        private Mock<IMapeRepository> mockMape;
        private Mock<IAutomatskaKupovinaServis> mockAutoKupovina;
        private Mock<IEliminacijaServis> mockEliminacija;
        private Mock<IProveraKrajaBitkeServis> mockProveraKraja;
        private SimulacijaBitkeServis servis;

        [SetUp]
        public void Setup()
        {
            mockHeroji = new Mock<IHerojiRepository>();
            mockTimovi = new Mock<ITimoviRepository>();
            mockMape = new Mock<IMapeRepository>();
            mockAutoKupovina = new Mock<IAutomatskaKupovinaServis>();
            mockEliminacija = new Mock<IEliminacijaServis>();
            mockProveraKraja = new Mock<IProveraKrajaBitkeServis>();

            var plaviHerojId = Guid.NewGuid();
            var crveniHerojId = Guid.NewGuid();

            var plaviHeroj = new Heroj("PlaviHeroj", 100, 50, 100) { Id = plaviHerojId };
            var crveniHeroj = new Heroj("CrveniHeroj", 80, 40, 80) { Id = crveniHerojId };

            var plaviIgraci = new List<Igrac> { new Igrac("PlaviIgrac", plaviHerojId) };
            var crveniIgraci = new List<Igrac> { new Igrac("CrveniIgrac", crveniHerojId) };

            var mapaLista = new List<Mapa>
            {
                new Mapa("TestMapa", Domain.Enumeracija.Tip_Mape.LETNJA, 10, "Crveni", "Plavi", 3)
            };

            var herojiLista = new List<Heroj> { plaviHeroj, crveniHeroj };

            // Postavi statičke liste u repozitorijumima preko refleksije
            var herojiProperty = typeof(HerojiRepository).GetProperty("Heroji", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            herojiProperty.SetValue(null, herojiLista);

            var plaviTimProperty = typeof(TimoviRepository).GetProperty("PlaviTim", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            plaviTimProperty.SetValue(null, plaviIgraci);

            var crveniTimProperty = typeof(TimoviRepository).GetProperty("CrveniTim", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            crveniTimProperty.SetValue(null, crveniIgraci);

            var pikovaniHerojiProperty = typeof(TimoviRepository).GetProperty("PikovaniHeroji", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            pikovaniHerojiProperty.SetValue(null, new List<Guid> { plaviHerojId, crveniHerojId });

            var mapeProperty = typeof(MapeRepository).GetProperty("Mape", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            mapeProperty.SetValue(null, mapaLista);

            mockHeroji.Setup(h => h.PronadjiPoId(plaviHerojId)).Returns(plaviHeroj);
            mockHeroji.Setup(h => h.PronadjiPoId(crveniHerojId)).Returns(crveniHeroj);

            mockTimovi.Setup(t => t.getPlaviTim()).Returns(plaviIgraci);
            mockTimovi.Setup(t => t.getCrveniTim()).Returns(crveniIgraci);

            mockMape.Setup(m => m.PronadjiMapuPoNazivu("TestMapa")).Returns(mapaLista[0]);

            mockAutoKupovina.Setup(a => a.ProveriNovac(It.IsAny<Igrac>(), It.IsAny<int>())).Returns("Mock kupovina izvršena.\n");
            mockEliminacija.Setup(e => e.EliminacijaHeroja(It.IsAny<Guid>(), It.IsAny<Guid>())).Returns(true);
            mockEliminacija.Setup(e => e.EliminacijaEntiteta(It.IsAny<Guid>(), It.IsAny<int>())).Returns(true);
            mockProveraKraja.Setup(p => p.ProveriKraj()).Returns(0);

            servis = new SimulacijaBitkeServis(mockAutoKupovina.Object, mockEliminacija.Object, mockProveraKraja.Object);
        }

        [Test]
        public void GenerisiVremeTrajanjaBitke_VracaBrojUOpsegu()
        {
            var vreme = servis.GenerisiVremeTrajanjaBitke();
            Assert.That(vreme, Is.InRange(10, 45));
        }

        [Test]
        public void SimulirajDogadjaj_VracaNeprazanString()
        {
            string rezultat = servis.SimulirajDogadjaj(30f, 1, "TestMapa");
            Assert.IsFalse(string.IsNullOrEmpty(rezultat));
        }
    }
}
