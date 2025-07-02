using NUnit.Framework;
using Moq;
using Services.AuthServisi;
using Domain.Repositories.KorisnickiRepository;
using System.Reflection;

namespace Testovi
{
    public class AuthServisTests
    {
        private Mock<IKorisnickiRepository> mockRepo;
        private AuthServis authServis;

        [SetUp]
        public void Setup()
        {
            mockRepo = new Mock<IKorisnickiRepository>();
            authServis = new AuthServis();

            // Zamenjujemo privatni field korisnickiRepository sa mockom putem refleksije
            var field = typeof(AuthServis).GetField("korisnickiRepository", BindingFlags.NonPublic | BindingFlags.Instance);
            field.SetValue(authServis, mockRepo.Object);
        }

        [Test]
        public void Autentifikacija_ValidniPodaci_VracaTrue()
        {
            mockRepo.Setup(r => r.PronadjiKorisnika("andrija", "andrija")).Returns(true);

            var rezultat = authServis.Autentifikacija("andrija", "andrija");

            Assert.IsTrue(rezultat);
            mockRepo.Verify(r => r.PronadjiKorisnika("andrija", "andrija"), Times.Once);
        }

        [Test]
        public void Autentifikacija_NevalidniPodaci_VracaFalse()
        {
            mockRepo.Setup(r => r.PronadjiKorisnika("neki", "losapass")).Returns(false);

            var rezultat = authServis.Autentifikacija("neki", "losapass");

            Assert.IsFalse(rezultat);
            mockRepo.Verify(r => r.PronadjiKorisnika("neki", "losapass"), Times.Once);
        }
    }
}
