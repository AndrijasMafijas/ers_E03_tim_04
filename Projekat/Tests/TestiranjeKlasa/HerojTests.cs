using NUnit.Framework;
using System;
using Domain.Modeli;

namespace Tests.TestiranjeKlasa
{
    public class HerojTests
    {
        [Test]
        public void PrazanKonstruktor_PodrazumevaneVrednosti()
        {
            Heroj heroj = new Heroj();

            Assert.AreEqual(string.Empty, heroj.NazivHeroja);
            Assert.AreEqual(0, heroj.ZivotniPoeni);
            Assert.AreEqual(0, heroj.JacinaNapada);
            Assert.AreEqual(0, heroj.TrenutnoNovcica);
            Assert.AreEqual(false, heroj.JelMrtav);
            Assert.AreNotEqual(Guid.Empty, heroj.Id);
        }

        [Test]
        public void ParametrizovaniKonstruktor_IspravneVrednosti()
        {
            string naziv = "Ratnik";
            int hp = 100;
            int dmg = 25;
            int novac = 50;

            Heroj heroj = new Heroj(naziv, hp, dmg, novac);

            Assert.AreEqual(naziv, heroj.NazivHeroja);
            Assert.AreEqual(hp, heroj.ZivotniPoeni);
            Assert.AreEqual(dmg, heroj.JacinaNapada);
            Assert.AreEqual(novac, heroj.TrenutnoNovcica);
            Assert.IsFalse(heroj.JelMrtav);
            Assert.AreNotEqual(Guid.Empty, heroj.Id);
        }

        [Test]
        public void SvakiHerojImaJedinstvenId()
        {
            var heroj1 = new Heroj("Heroj1", 100, 20, 30);
            var heroj2 = new Heroj("Heroj2", 100, 20, 30);

            Assert.AreNotEqual(heroj1.Id, heroj2.Id);
        }

        [Test]
        public void PromenaZivotnihPoena_MozeDaSePostavi()
        {
            var heroj = new Heroj("Test", 100, 20, 30);

            heroj.ZivotniPoeni = 50;

            Assert.AreEqual(50, heroj.ZivotniPoeni);
        }

        [Test]
        public void PostavljanjeHerojaKaoMrtvog()
        {
            var heroj = new Heroj("Mrtvac", 0, 0, 0);

            heroj.JelMrtav = true;

            Assert.IsTrue(heroj.JelMrtav);
        }
    }
}
