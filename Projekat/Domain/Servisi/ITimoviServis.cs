using Domain.Modeli;
using Domain.Repositories.HerojiRepository;
using Domain.Repositories.TimoviRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servisi
{
    public interface ITimoviServis
    {
        bool DodavanjeIgracaUPlaviTim(Igrac x);
        bool DodavanjeIgracaUCrveniTim(Igrac x);

        public Guid PronadjiHeroja(string x);

        public string IspisiListuHeroja();


        public bool PronadjiHeroja(Guid g);
        
    }
}
