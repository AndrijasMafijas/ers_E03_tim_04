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
        public bool DodavanjeIgracaUPlaviTim(Igrac x) 
        {
            return timovi.DodajUPlaviTim(x);
        }
        public bool DodavanjeIgracaUCrveniTim(Igrac x)
        {
            return timovi.DodajUCrveniTim(x);
        }
    }
}
