using NUnit.Framework;
using Moq;
using Services.BitkaServisi;
using Domain.Repositories.HerojiRepository;
using Domain.Modeli;
using System;
using System.Reflection;

namespace Testovi
{
    public class EliminacijaServisTests
    {
        private Mock<IHerojiRepository> mockHerojiRepo;
        private EliminacijaServis servis;

        [SetUp]
        public void Setup()
        {
            mockHerojiRepo = new Mock<IHerojiRepository>();
            servis = new EliminacijaServis();

            var field = typeof(EliminacijaServis).GetField("_herojiRepository", BindingFlags.NonPublic | BindingFlags.Instance);
            field.SetValue(servis, mockHerojiRepo.Object);
        }

        [Test]
        public void EliminacijaHeroja_PobednikImaPrazanNaziv_VracaFalse()
        {
            var pobednikId = Guid.NewGuid();
            var gubitnikId = Guid.NewGuid();

            mockHerojiRepo.Setup(r => r.PronadjiPoId(pobednikId)).Returns(new Heroj());
            mockHerojiRepo.Setup(r => r.PronadjiPoId(gubitnikId)).Returns(new Heroj() { NazivHeroja = "Gubitnik" });

            var result = servis.EliminacijaHeroja(pobednikId, gubitnikId);

            Assert.IsFalse(result);
        }

        [Test]
        public void EliminacijaHeroja_GubitnikImaPrazanNaziv_VracaFalse()
        {
            var pobednikId = Guid.NewGuid();
            var gubitnikId = Guid.NewGuid();

            mockHerojiRepo.Setup(r => r.PronadjiPoId(pobednikId)).Returns(new Heroj() { NazivHeroja = "Pobednik" });
            mockHerojiRepo.Setup(r => r.PronadjiPoId(gubitnikId)).Returns(new Heroj());

            var result = servis.EliminacijaHeroja(pobednikId, gubitnikId);

            Assert.IsFalse(result);
        }

        [Test]
        public void EliminacijaHeroja_HerojNijeUbijen_VracaFalse()
        {
            var pobednikId = Guid.NewGuid();
            var gubitnikId = Guid.NewGuid();

            mockHerojiRepo.Setup(r => r.PronadjiPoId(pobednikId)).Returns(new Heroj() { NazivHeroja = "Pobednik" });
            mockHerojiRepo.Setup(r => r.PronadjiPoId(gubitnikId)).Returns(new Heroj() { NazivHeroja = "Gubitnik" });
            mockHerojiRepo.Setup(r => r.HerojUbijen(gubitnikId)).Returns(false);

            var result = servis.EliminacijaHeroja(pobednikId, gubitnikId);

            Assert.IsFalse(result);
        }

        [Test]
        public void EliminacijaHeroja_SveIspravno_VracaTrueINadodaNovcice()
        {
            var pobednikId = Guid.NewGuid();
            var gubitnikId = Guid.NewGuid();
            var pobednik = new Heroj() { Id = pobednikId, NazivHeroja = "Pobednik", TrenutnoNovcica = 100 };
            var gubitnik = new Heroj() { Id = gubitnikId, NazivHeroja = "Gubitnik" };

            mockHerojiRepo.Setup(r => r.PronadjiPoId(pobednikId)).Returns(pobednik);
            mockHerojiRepo.Setup(r => r.PronadjiPoId(gubitnikId)).Returns(gubitnik);
            mockHerojiRepo.Setup(r => r.HerojUbijen(gubitnikId)).Returns(true);

            var result = servis.EliminacijaHeroja(pobednikId, gubitnikId);

            Assert.IsTrue(result);
            Assert.AreEqual(400, pobednik.TrenutnoNovcica); // 100 + 300
        }

        [Test]
        public void EliminacijaEntiteta_HerojPostoji_VracaTrueINadodaNovcice()
        {
            var herojId = Guid.NewGuid();
            var heroj = new Heroj() { Id = herojId, NazivHeroja = "Heroj", TrenutnoNovcica = 10 };

            mockHerojiRepo.Setup(r => r.PronadjiPoId(herojId)).Returns(heroj);

            var result = servis.EliminacijaEntiteta(herojId, 50);

            Assert.IsTrue(result);
            Assert.AreEqual(60, heroj.TrenutnoNovcica);
        }

        [Test]
        public void EliminacijaEntiteta_HerojNePostoji_VracaFalse()
        {
            var herojId = Guid.NewGuid();

            mockHerojiRepo.Setup(r => r.PronadjiPoId(herojId)).Returns(new Heroj());

            var result = servis.EliminacijaEntiteta(herojId, 50);

            Assert.IsFalse(result);
        }
    }
}
