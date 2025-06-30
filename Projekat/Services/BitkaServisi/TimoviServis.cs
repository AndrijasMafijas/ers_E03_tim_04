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
        ITimoviRepository timovi = new TimoviRepository();
        IHerojiRepository heroji = new HerojiRepository();
        public bool DodavanjeIgracaUPlaviTim(Igrac x) 
        {
            return timovi.DodajUPlaviTim(x);
        }
        public bool DodavanjeIgracaUCrveniTim(Igrac x)
        {
            return timovi.DodajUCrveniTim(x);
        }
        public Guid PronadjiHeroja(string x)
        {
            Heroj h = heroji.PronadjiPoImenu(x);
            if (h.NazivHeroja != string.Empty) return h.Id;
            else return Guid.Empty;
        }
        public string IspisiListuHeroja()
        {
            return heroji.IspisiListu();
        }

        public bool PronadjiHeroja(Guid g)
        {
            return timovi.PronadjiHeroja(g);
        }
    }
}
