using NUnit.Framework;
using Moq;
using Services.BitkaServisi;
using Domain.Repositories.HerojiRepository;
using Domain.Repositories.TimoviRepository;
using Domain.Modeli;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Testovi
{
    public class ProveraKrajaBitkeServisTests
    {
        private Mock<ITimoviRepository> mockTimoviRepo;
        private Mock<IHerojiRepository> mockHerojiRepo;
        private ProveraKrajaBitkeServis servis;

        [SetUp]
        public void Setup()
        {
            mockTimoviRepo = new Mock<ITimoviRepository>();
            mockHerojiRepo = new Mock<IHerojiRepository>();
            servis = new ProveraKrajaBitkeServis();

            var timoviField = typeof(ProveraKrajaBitkeServis).GetField("timovi", BindingFlags.NonPublic | BindingFlags.Instance);
            timoviField.SetValue(servis, mockTimoviRepo.Object);

            var herojiField = typeof(ProveraKrajaBitkeServis).GetField("heroji", BindingFlags.NonPublic | BindingFlags.Instance);
            herojiField.SetValue(servis, mockHerojiRepo.Object);
        }

        [Test]
        public void ProveriKraj_NemaZivihUCrvenomTimu_Vrati1()
        {
            var crveniIgrac = new Igrac("CrveniIgrac", Guid.NewGuid());
            var mrtviHeroj = new Heroj() { Id = crveniIgrac.getIdHeroja(), JelMrtav = true };

            mockTimoviRepo.Setup(t => t.getCrveniTim()).Returns(new List<Igrac> { crveniIgrac });
            mockTimoviRepo.Setup(t => t.getPlaviTim()).Returns(new List<Igrac>());
            mockHerojiRepo.Setup(h => h.VratiSveHeroje()).Returns(new List<Heroj> { mrtviHeroj });

            var rezultat = servis.ProveriKraj();

            Assert.AreEqual(1, rezultat);
        }

        [Test]
        public void ProveriKraj_NemaZivihUPlavomTimu_Vrati2()
        {
            var crveniIgrac = new Igrac("CrveniIgrac", Guid.NewGuid());
            var plaviIgrac = new Igrac("PlaviIgrac", Guid.NewGuid());
            var ziviCrveniHeroj = new Heroj() { Id = crveniIgrac.getIdHeroja(), JelMrtav = false };
            var mrtviPlaviHeroj = new Heroj() { Id = plaviIgrac.getIdHeroja(), JelMrtav = true };

            mockTimoviRepo.Setup(t => t.getCrveniTim()).Returns(new List<Igrac> { crveniIgrac });
            mockTimoviRepo.Setup(t => t.getPlaviTim()).Returns(new List<Igrac> { plaviIgrac });
            mockHerojiRepo.Setup(h => h.VratiSveHeroje()).Returns(new List<Heroj> { ziviCrveniHeroj, mrtviPlaviHeroj });

            var rezultat = servis.ProveriKraj();

            Assert.AreEqual(2, rezultat);
        }

        [Test]
        public void ProveriKraj_ImaZivihObaTima_Vrati0()
        {
            var crveniIgrac = new Igrac("CrveniIgrac", Guid.NewGuid());
            var plaviIgrac = new Igrac("PlaviIgrac", Guid.NewGuid());
            var ziviCrveniHeroj = new Heroj() { Id = crveniIgrac.getIdHeroja(), JelMrtav = false };
            var ziviPlaviHeroj = new Heroj() { Id = plaviIgrac.getIdHeroja(), JelMrtav = false };

            mockTimoviRepo.Setup(t => t.getCrveniTim()).Returns(new List<Igrac> { crveniIgrac });
            mockTimoviRepo.Setup(t => t.getPlaviTim()).Returns(new List<Igrac> { plaviIgrac });
            mockHerojiRepo.Setup(h => h.VratiSveHeroje()).Returns(new List<Heroj> { ziviCrveniHeroj, ziviPlaviHeroj });

            var rezultat = servis.ProveriKraj();

            Assert.AreEqual(0, rezultat);
        }

        [Test]
        public void KolikoJeZivihUPlavomTimu_RacunaBrojZivih()
        {
            var plaviIgrac1 = new Igrac("Plavi1", Guid.NewGuid());
            var plaviIgrac2 = new Igrac("Plavi2", Guid.NewGuid());

            var plaviTim = new List<Igrac> { plaviIgrac1, plaviIgrac2 };
            mockTimoviRepo.Setup(t => t.getPlaviTim()).Returns(plaviTim);

            var heroji = new List<Heroj> {
                new Heroj() { Id = plaviIgrac1.getIdHeroja(), JelMrtav = false },
                new Heroj() { Id = plaviIgrac2.getIdHeroja(), JelMrtav = true }, // mrtav ne racuna
                new Heroj() { Id = Guid.NewGuid(), JelMrtav = false } // nije na plavom timu
            };
            mockHerojiRepo.Setup(h => h.VratiSveHeroje()).Returns(heroji);

            var rezultat = servis.KolikoJeZivihUPlavomTimu();

            Assert.AreEqual(1, rezultat);
        }

        [Test]
        public void KolikoJeZivihUCrvenomTimu_RacunaBrojZivih()
        {
            var crveniIgrac1 = new Igrac("Crveni1", Guid.NewGuid());
            var crveniIgrac2 = new Igrac("Crveni2", Guid.NewGuid());

            var crveniTim = new List<Igrac> { crveniIgrac1, crveniIgrac2 };
            mockTimoviRepo.Setup(t => t.getCrveniTim()).Returns(crveniTim);

            var heroji = new List<Heroj> {
                new Heroj() { Id = crveniIgrac1.getIdHeroja(), JelMrtav = false },
                new Heroj() { Id = crveniIgrac2.getIdHeroja(), JelMrtav = true }, // mrtav ne racuna
                new Heroj() { Id = Guid.NewGuid(), JelMrtav = false } // nije na crvenom timu
            };
            mockHerojiRepo.Setup(h => h.VratiSveHeroje()).Returns(heroji);

            var rezultat = servis.KolikoJeZivihUCrvenomTimu();

            Assert.AreEqual(1, rezultat);
        }
    }
}
