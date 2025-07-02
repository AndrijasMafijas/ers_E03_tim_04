using NUnit.Framework;
using Domain.Modeli;
using System.Collections.Generic;

namespace Testovi
{
    public class ProdavnicaTests
    {
        [Test]
        public void PrazanKonstruktor_PodrazumevaneVrednosti()
        {
            var prodavnica = new Prodavnica();

            Assert.AreEqual(0, prodavnica.ID);
            Assert.AreEqual(0, prodavnica.UkupnoProdato);
            Assert.IsNotNull(prodavnica.ListaOruzja);
            Assert.IsNotNull(prodavnica.ListaNapitaka);
            Assert.AreEqual(0, prodavnica.ListaOruzja.Count);
            Assert.AreEqual(0, prodavnica.ListaNapitaka.Count);
        }

        [Test]
        public void ParametrizovaniKonstruktor_IspravneVrednosti()
        {
            var oruzja = new List<Oruzje>()
            {
                new Oruzje("Mac", 100, 20, 1),
                new Oruzje("Sekira", 150, 25, 2)
            };

            var napici = new List<Napitak>()
            {
                new Napitak("Zdravlje", 50, 0, 3),
                new Napitak("Snaga", 75, 10, 2)
            };

            var prodavnica = new Prodavnica(1, 5, oruzja, napici);

            Assert.AreEqual(1, prodavnica.ID);
            Assert.AreEqual(5, prodavnica.UkupnoProdato);
            Assert.AreEqual(2, prodavnica.ListaOruzja.Count);
            Assert.AreEqual(2, prodavnica.ListaNapitaka.Count);
            Assert.AreEqual("Mac", prodavnica.ListaOruzja[0].NazivOruzja);
            Assert.AreEqual("Zdravlje", prodavnica.ListaNapitaka[0].NazivNapitka);
        }

        [Test]
        public void DodavanjeOruzjaURucnoNapunjenuListu()
        {
            var prodavnica = new Prodavnica();
            prodavnica.ListaOruzja.Add(new Oruzje("Koplje", 80, 15, 1));

            Assert.AreEqual(1, prodavnica.ListaOruzja.Count);
            Assert.AreEqual("Koplje", prodavnica.ListaOruzja[0].NazivOruzja);
        }

        [Test]
        public void DodavanjeNapitkaURucnoNapunjenuListu()
        {
            var prodavnica = new Prodavnica();
            prodavnica.ListaNapitaka.Add(new Napitak("Energija", 40, 5, 1));

            Assert.AreEqual(1, prodavnica.ListaNapitaka.Count);
            Assert.AreEqual("Energija", prodavnica.ListaNapitaka[0].NazivNapitka);
        }
    }
}
