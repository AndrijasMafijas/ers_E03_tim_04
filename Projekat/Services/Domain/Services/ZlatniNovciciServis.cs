using Domain.Modeli;
using Domain.Servisi;
using Domain.Repositories.HerojiRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.Services
{
    public class ZlatniNovciciServis : IZlatniNovciciServis
    {
        public bool EliminacijaHeroja(Heroj pobednik,Heroj gubitnik)
        {
            if(!HerojiRepository.UkloniHeroja(gubitnik))
                return false;
            pobednik.TrenutnoNovcica += 300;
            return true;
        }
        public bool EliminacijaEntiteta(Heroj pobednik)
        {
            Random random = new Random();
            pobednik.TrenutnoNovcica += (int)random.NextInt64(20, 90);
            return true;
        }
    }
}
