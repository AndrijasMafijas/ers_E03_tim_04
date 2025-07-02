using NUnit.Framework;
using Domain.Modeli;
using Domain.Enumeracija;

namespace Testovi
{
    public class MapaTests
    {
        [Test]
        public void PrazanKonstruktor_PodrazumevaneVrednosti()
        {
            var mapa = new Mapa();

            Assert.AreEqual(string.Empty, mapa.NazivMape);
            Assert.AreEqual((Tip_Mape)0, mapa.Tip_Mape);
            Assert.AreEqual(0, mapa.MaksimalanBrojIgraca);
            Assert.AreEqual(string.Empty, mapa.NazivCrvenih);
            Assert.AreEqual(string.Empty, mapa.NazivPlavih);
            Assert.AreEqual(0, mapa.BrojPomocnih);
        }

        [Test]
        public void ParametrizovaniKonstruktor_IspravneVrednosti()
        {
            var mapa = new Mapa("Ledena Dolina", Tip_Mape.ZIMSKA, 8, "Ledeni", "Snegovi", 3);

            Assert.AreEqual("Ledena Dolina", mapa.NazivMape);
            Assert.AreEqual(Tip_Mape.ZIMSKA, mapa.Tip_Mape);
            Assert.AreEqual(8, mapa.MaksimalanBrojIgraca);
            Assert.AreEqual("Ledeni", mapa.NazivCrvenih);
            Assert.AreEqual("Snegovi", mapa.NazivPlavih);
            Assert.AreEqual(3, mapa.BrojPomocnih);
        }

        [Test]
        public void PromenaNazivaMape()
        {
            var mapa = new Mapa();
            mapa.NazivMape = "Letnja Oaza";

            Assert.AreEqual("Letnja Oaza", mapa.NazivMape);
        }

        [Test]
        public void PromenaTipaMape()
        {
            var mapa = new Mapa();
            mapa.Tip_Mape = Tip_Mape.LETNJA;

            Assert.AreEqual(Tip_Mape.LETNJA, mapa.Tip_Mape);
        }

        [Test]
        public void PromenaNazivaTimova()
        {
            var mapa = new Mapa();
            mapa.NazivCrvenih = "Sunce";
            mapa.NazivPlavih = "More";

            Assert.AreEqual("Sunce", mapa.NazivCrvenih);
            Assert.AreEqual("More", mapa.NazivPlavih);
        }
    }
}
