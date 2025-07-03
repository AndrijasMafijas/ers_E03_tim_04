using Domain.Modeli;
using Domain.Repositories.HerojiRepository;
using Domain.Repositories.TimoviRepository;
using Domain.Servisi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BitkaServisi
{
    public class HerojiServis : IHerojiServis
    {
        ITimoviRepository timovi = new TimoviRepository();
        IHerojiRepository heroji = new HerojiRepository();
        public HerojiServis() { }
        public List<Heroj> GetPlaviTimHeroje()
        {
            List<Igrac> igraciPlavogTima = timovi.getPlaviTim();
            List<Heroj> sviHeroji = heroji.VratiSveHeroje();
            List<Heroj> igraniHeroji = new List<Heroj>();
            foreach(Igrac i in igraciPlavogTima)
                foreach(Heroj h in sviHeroji)
                    if(i.getIdHeroja() == h.Id) igraniHeroji.Add(h);
            return igraniHeroji;
        }
        public List<Heroj> GetCrveniTimHeroje()
        {
            List<Igrac> igraciCrvenogTima = timovi.getCrveniTim();
            List<Heroj> sviHeroji = heroji.VratiSveHeroje();
            List<Heroj> igraniHeroji = new List<Heroj>();
            foreach (Igrac i in igraciCrvenogTima)
                foreach (Heroj h in sviHeroji)
                    if (i.getIdHeroja() == h.Id) igraniHeroji.Add(h);
            return igraniHeroji;
        }
        public string IspisiListuHeroja()
        {
            return heroji.IspisiListu();
        }
        public bool PronadjiHeroja(Guid g)
        {
            return timovi.PronadjiHeroja(g);
        }
        public Guid PronadjiHeroja(string x)
        {
            Heroj h = heroji.PronadjiPoImenu(x);
            if (h.NazivHeroja != string.Empty) return h.Id;
            else return Guid.Empty;
        }
    }
}
