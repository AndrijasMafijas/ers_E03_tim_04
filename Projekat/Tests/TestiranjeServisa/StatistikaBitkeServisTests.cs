using Domain.Servisi;
using Moq;
using NUnit.Framework;
using Services.BitkaServisi;

namespace Tests
{
    public class StatistikaBitkeServisTests
    {
        private Mock<IGeneratorStatistikeBitkeServis> mockGenerator;
        private StatistikaBitkeServis servis;

        [SetUp]
        public void Setup()
        {
            mockGenerator = new Mock<IGeneratorStatistikeBitkeServis>();
            servis = new StatistikaBitkeServis(mockGenerator.Object);
        }

        [Test]
        public void IspisiNaEkran_PozivaGeneratorISvraćaString()
        {
            // Arrange
            string nazivMape = "TestMapa";
            int idProdavnice = 1;
            string ocekivaniString = "Neki tekst statistike";

            mockGenerator
                .Setup(g => g.IspisiStatistikuBitke(idProdavnice, nazivMape))
                .Returns(ocekivaniString);

            // Act
            var rezultat = servis.IspisiNaEkran(nazivMape, idProdavnice);

            // Assert
            Assert.IsNotNull(rezultat);
            Assert.AreEqual(ocekivaniString, rezultat);
            mockGenerator.Verify(g => g.IspisiStatistikuBitke(idProdavnice, nazivMape), Times.Once);
        }
    }
}
