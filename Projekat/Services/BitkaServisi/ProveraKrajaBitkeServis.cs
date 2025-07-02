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
    public class ProveraKrajaBitkeServis : IProveraKrajaBitkeServis
    {
        ITimoviRepository timovi = new TimoviRepository();
        IHerojiRepository heroji = new HerojiRepository();
        public int ProveriKraj()
        {
            if (KolikoJeZivihUCrvenomTimu() == 0)
            {
                return 1;
            }
            if (KolikoJeZivihUPlavomTimu() == 0)
            {
                return 2;
            }
            return 0;
        }

        public int KolikoJeZivihUPlavomTimu()
        {
           int broj = 0;
           foreach (Igrac p in timovi.getPlaviTim())
            {
                foreach(Heroj h in heroji.VratiSveHeroje())
                {
                    if(p.getIdHeroja() == h.Id && !h.JelMrtav)
                    {
                        broj++;
                    }
                }
            }
            return broj;
        }
        public int KolikoJeZivihUCrvenomTimu()
        {
            int broj = 0;
            foreach (Igrac p in timovi.getCrveniTim())
            {
                foreach (Heroj h in heroji.VratiSveHeroje())
                {
                    if (p.getIdHeroja() == h.Id && !h.JelMrtav)
                    {
                        broj++;
                    }
                }
            }
            return broj;
        }
    }
}
