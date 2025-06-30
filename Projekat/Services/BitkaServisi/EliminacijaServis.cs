using Domain.Modeli;
using Domain.PomocneMetode;
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
    public class EliminacijaServis : IEliminacijaServis
    {
        IHerojiRepository _herojiRepository = new HerojiRepository();
        ITimoviRepository timovi = new TimoviRepository();
        //GeneratorNovcica generator = new GeneratorNovcica();
        public bool EliminacijaHeroja(Guid pobednik,Guid gubitnik)
        {
            Heroj pobednikk = _herojiRepository.PronadjiPoId(pobednik);
            Heroj gubitnikk = _herojiRepository.PronadjiPoId(gubitnik);
            if (pobednikk.NazivHeroja == string.Empty)
            {
                return false;
            }
            if(gubitnikk.NazivHeroja == string.Empty)
            {
                return false;
            }
            if(!_herojiRepository.HerojUbijen(gubitnik))
                return false;
            pobednikk.TrenutnoNovcica += 300;
            return true;
        }
        public bool EliminacijaEntiteta(Guid pobednik, int brojka)
        {
            Heroj heroj = _herojiRepository.PronadjiPoId(pobednik);
            if (heroj.NazivHeroja != string.Empty)
            {
                heroj.TrenutnoNovcica += brojka;
                return true;
            }
            return false;
        }
    }
}
