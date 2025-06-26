using Domain.Modeli;
using Domain.Servisi;
using Domain.Repositories.HerojiRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.PomocneMetode;

namespace Services.BitkaServisi
{
    public class EliminacijaServis : IEliminacijaServis
    {
        IHerojiRepository _herojiRepository = new HerojiRepository();
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
            if(!_herojiRepository.UkloniHeroja(gubitnik))
                return false;
            pobednikk.TrenutnoNovcica += 300;
            return true;
        }
        public bool EliminacijaEntiteta(Guid pobednik)
        {
            Heroj heroj = _herojiRepository.PronadjiPoId(pobednik);
            if (heroj.NazivHeroja != string.Empty)
            {
                heroj.TrenutnoNovcica += GeneratorNovcica.EliminacijaEntiteta();
                return true;
            }
            return false;
        }
    }
}
