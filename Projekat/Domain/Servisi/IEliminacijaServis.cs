using Domain.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servisi
{
    public interface IEliminacijaServis
    {
        public bool EliminacijaHeroja(Guid pobednik, Guid gubitnik );

        public bool EliminacijaEntiteta(Guid pobednik, int brojka);
    }
}
