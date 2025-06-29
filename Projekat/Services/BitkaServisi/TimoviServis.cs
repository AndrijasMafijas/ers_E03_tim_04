using Domain.Modeli;
using Domain.Servisi;
using Domain.Repositories.HerojiRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Repositories.TimoviRepository;

namespace Services.BitkaServisi
{
    public class TimoviServis : ITimoviServis
    {
        public bool DodavanjeIgracaUPlaviTim(Igrac x) 
        {
            ITimoviRepository timovi = new TimoviRepository();
            return timovi.DodajUPlaviTim(x);
        }
        public bool DodavanjeIgracaUCrveniTim(Igrac x)
        {
            ITimoviRepository timovi = new TimoviRepository();
            return timovi.DodajUCrveniTim(x);
        }
        public Guid PronadjiHeroja(string x)
        {
            IHerojiRepository heroji = new HerojiRepository();
            Heroj h = heroji.PronadjiPoImenu(x);
            if (h.NazivHeroja != string.Empty) return h.Id;
            else return Guid.Empty;
        }
        public string IspisiListuHeroja()
        {
            IHerojiRepository heroji = new HerojiRepository();
            return heroji.IspisiListu();
        }

        public bool PronadjiHeroja(Guid g)
        {
            ITimoviRepository timovi = new TimoviRepository();
            return timovi.PronadjiHeroja(g);
        }
    }
}
