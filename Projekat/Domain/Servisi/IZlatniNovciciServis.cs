using Domain.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servisi
{
    public interface IZlatniNovciciServis
    {
        public bool EliminacijaHeroja(Heroj pobednik, Heroj gubitnik);

        public bool EliminacijaEntiteta(Heroj pobednik);
    }
}
