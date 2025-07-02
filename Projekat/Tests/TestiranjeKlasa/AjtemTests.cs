using NUnit.Framework;
using Domain.Modeli;

namespace Testovi
{
    public class AjtemTests
    {
        [Test]
        public void Oruzje_NasledjujeAjtem_VrednostiIspravnoPostavljene()
        {
            var oruzje = new Oruzje("Sekira", 120, 30, 2);

            Assert.AreEqual(120, oruzje.Cena);
            Assert.AreEqual(30, oruzje.PojacanjeNapada);
            Assert.AreEqual(2, oruzje.DostupnoZaKupovinu);
        }

        [Test]
        public void Napitak_NasledjujeAjtem_VrednostiIspravnoPostavljene()
        {
            var napitak = new Napitak("Moc", 60, 15, 4);

            Assert.AreEqual(60, napitak.Cena);
            Assert.AreEqual(15, napitak.PojacanjeNapada);
            Assert.AreEqual(4, napitak.DostupnoZaKupovinu);
        }

        [Test]
        public void PromenaVrednostiNaAjtemu_KrozOruzje()
        {
            var oruzje = new Oruzje("Mac", 100, 20, 3);

            oruzje.Cena = 150;
            oruzje.PojacanjeNapada = 35;
            oruzje.DostupnoZaKupovinu = 5;

            Assert.AreEqual(150, oruzje.Cena);
            Assert.AreEqual(35, oruzje.PojacanjeNapada);
            Assert.AreEqual(5, oruzje.DostupnoZaKupovinu);
        }

        [Test]
        public void PromenaVrednostiNaAjtemu_KrozNapitak()
        {
            var napitak = new Napitak("Snaga", 45, 10, 2);

            napitak.Cena = 70;
            napitak.PojacanjeNapada = 25;
            napitak.DostupnoZaKupovinu = 1;

            Assert.AreEqual(70, napitak.Cena);
            Assert.AreEqual(25, napitak.PojacanjeNapada);
            Assert.AreEqual(1, napitak.DostupnoZaKupovinu);
        }
    }
}
