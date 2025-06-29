using Domain.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.TimoviRepository
{
    public interface ITimoviRepository
    {
        bool DodajUPlaviTim(Igrac x);
        bool DodajUCrveniTim(Igrac x);
        List<Igrac> getCrveniTim();
        List<Igrac> getPlaviTim();
    }
}
