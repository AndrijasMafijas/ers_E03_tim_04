using Domain.Modeli;
using Domain.Repositories.HerojiRepository;
using Domain.Repositories.ProdavnicaRepository;
using Moq;
using Services.ProdavnicaServisi;

namespace Tests
{
    [TestFixture]
    public class AutomatskaKupovinaServisTests
    {
        private Mock<IHerojiRepository> mockHeroji;
        private Mock<IProdavnicaRepository> mockProdavnice;
        private AutomatskaKupovinaServis servis;
        private Guid herojId = Guid.NewGuid();

        [SetUp]
        public void Setup()
        {
            mockHeroji = new Mock<IHerojiRepository>();
            mockProdavnice = new Mock<IProdavnicaRepository>();

            var heroj = new Heroj("TestHeroj", 50, 100, 1500) { Id = herojId };
            heroj.TrenutnoNovcica = 1500;
            heroj.JacinaNapada = 50;

            var oruzje = new Oruzje("TestOruzje", 100, 100, 10) { DostupnoZaKupovinu = 2 };
            var napitak = new Napitak("TestNapitak", 150, 150, 5) { DostupnoZaKupovinu = 1 };

            var prodavnica = new Prodavnica(1, 0, new List<Oruzje> { oruzje }, new List<Napitak> { napitak });

            mockHeroji.Setup(h => h.PronadjiPoId(herojId)).Returns(heroj);
            mockProdavnice.Setup(p => p.PronadjiProdavnicuPoIdu(1)).Returns(prodavnica);
            mockProdavnice.Setup(p => p.prodajOruzje(It.IsAny<Oruzje>(), 1)).Returns<Oruzje, int>((o, id) =>
            {
                if (o.DostupnoZaKupovinu > 0)
                {
                    o.DostupnoZaKupovinu--;
                    return true;
                }
                return false;
            });
            mockProdavnice.Setup(p => p.prodajNapitak(It.IsAny<Napitak>(), 1)).Returns<Napitak, int>((n, id) =>
            {
                if (n.DostupnoZaKupovinu > 0)
                {
                    n.DostupnoZaKupovinu--;
                    return true;
                }
                return false;
            });

            servis = new AutomatskaKupovinaServis();
        }

        [Test]
        public void ProveriNovac_VracaNeprazanString_KadaImaDovoljnoNovca()
        {
            var servis = new AutomatskaKupovinaServis();

            // Kreiraj mockove
            var mockHeroji = new Mock<IHerojiRepository>();
            var mockProdavnica = new Mock<IProdavnicaRepository>();

            // Napravi heroja sa dovoljno novca
            var herojId = Guid.NewGuid();
            var heroj = new Heroj("TestHeroj", 50, 50, 1000) { Id = herojId };
            mockHeroji.Setup(h => h.PronadjiPoId(herojId)).Returns(heroj);

            // Napravi listu oruzja i napitaka
            var oruzjeLista = new List<Oruzje> { new Oruzje("OruzjeTest", 100, 10, 1) };
            var napitakLista = new List<Napitak> { new Napitak("NapitakTest", 100, 10, 1) };

            // Napravi prodavnicu sa listama
            var prodavnica = new Prodavnica(1, 0, oruzjeLista, napitakLista);
            mockProdavnica.Setup(p => p.PronadjiProdavnicuPoIdu(1)).Returns(prodavnica);

            // Mockuj metode prodaje da uvek vrate true
            mockProdavnica.Setup(p => p.prodajOruzje(It.IsAny<Oruzje>(), 1)).Returns(true);
            mockProdavnica.Setup(p => p.prodajNapitak(It.IsAny<Napitak>(), 1)).Returns(true);

            // Reflection da zameniš privatna polja 'heroji' i 'prodavnice' u servisu
            var herojiField = typeof(AutomatskaKupovinaServis).GetField("heroji", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var prodavniceField = typeof(AutomatskaKupovinaServis).GetField("prodavnice", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            herojiField.SetValue(servis, mockHeroji.Object);
            prodavniceField.SetValue(servis, mockProdavnica.Object);

            // Kreiraj igraca sa istim hero id-jem
            var igrac = new Igrac("IgracTest", herojId);

            string rezultat = servis.ProveriNovac(igrac, 1);

            Assert.IsFalse(string.IsNullOrEmpty(rezultat));
        }

    }
}
