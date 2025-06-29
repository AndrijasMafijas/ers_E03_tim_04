using Domain.Modeli;
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
    }
}
