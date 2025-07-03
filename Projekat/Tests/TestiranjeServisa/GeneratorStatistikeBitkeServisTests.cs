using NUnit.Framework;
using Moq;
using Domain.Repositories.HerojiRepository;
using Domain.Repositories.TimoviRepository;
using Domain.Repositories.ProdavnicaRepository;
using Domain.Repositories.MapeRepository;
using Services.BitkaServisi;
using Domain.Modeli;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class GeneratorStatistikeBitkeServisTests
    {
        private Mock<IHerojiRepository> mockHeroji;
        private Mock<ITimoviRepository> mockTimovi;
        private Mock<IProdavnicaRepository> mockProdavnice;
        private Mock<IMapeRepository> mockMape;

        private GeneratorStatistikeBitkeServis generator;

        [SetUp]
        public void Setup()
        {
            mockHeroji = new Mock<IHerojiRepository>();
            mockTimovi = new Mock<ITimoviRepository>();
            mockProdavnice = new Mock<IProdavnicaRepository>();
            mockMape = new Mock<IMapeRepository>();

            // Kreiraj testne podatke
            var heroId1 = Guid.NewGuid();
            var heroId2 = Guid.NewGuid();

            var herojiLista = new List<Heroj>
            {
                new Heroj(heroId1 , "Hero1", 100, 50, 10),
                new Heroj(heroId2, "Hero2", 90, 40, 20)
            };

            var plaviTim = new List<Igrac> { new Igrac("PlaviIgrac1", heroId1) };
            var crveniTim = new List<Igrac> { new Igrac("CrveniIgrac1", heroId2) };

            var prodavnica = new Prodavnica(1, 1000, new List<Oruzje>(), new List<Napitak>());
            var mapa = new Mapa("Test", Domain.Enumeracija.Tip_Mape.LETNJA, 10, "Orlovi", "Tigrovi", 5);

            // Setup mock-ova
            mockHeroji.Setup(r => r.PronadjiPoId(It.IsAny<Guid>()))
                .Returns<Guid>(id => herojiLista.Find(h => h.Id == id) ?? new Heroj());

            mockTimovi.Setup(r => r.getPlaviTim()).Returns(plaviTim);
            mockTimovi.Setup(r => r.getCrveniTim()).Returns(crveniTim);

            mockProdavnice.Setup(r => r.PronadjiProdavnicuPoIdu(1)).Returns(prodavnica);
            mockMape.Setup(r => r.PronadjiMapuPoNazivu("Test")).Returns(mapa);

            // Inicijalizuj servis sa mockovima
            generator = new GeneratorStatistikeBitkeServis(
                mockHeroji.Object,
                mockTimovi.Object,
                mockProdavnice.Object,
                mockMape.Object);
        }

        [Test]
        public void IspisiStatistikuBitke_VracaOcekivaniString()
        {
            // Act
            var rezultat = generator.IspisiStatistikuBitke(1, "Test");

            // Assert
            Assert.IsNotNull(rezultat);
            Assert.IsTrue(rezultat.Contains("===== BATTLE STATISTICS ====="));
            Assert.IsTrue(rezultat.Contains(">>> RED TEAM:"));
            Assert.IsTrue(rezultat.Contains(">>> BLUE TEAM:"));
            Assert.IsTrue(rezultat.Contains(">>> MAP:"));
            Assert.IsTrue(rezultat.Contains(">>> SHOP:"));
            Assert.IsTrue(rezultat.Contains("Test"));
            Assert.IsTrue(rezultat.Contains("TOTAL REVENUE:"));
            Assert.IsTrue(rezultat.Contains("Hero1") || rezultat.Contains("Hero2"));
            Assert.IsTrue(rezultat.Contains("PlaviIgrac1") || rezultat.Contains("CrveniIgrac1"));
        }
    }
}
