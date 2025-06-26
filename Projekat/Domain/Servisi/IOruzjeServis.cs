using Domain.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servisi
{
    public interface IOruzjeServis
    {
        public IEnumerable<Oruzje> getListaOruzja(Prodavnica p);
        public bool DodajOruzje(Prodavnica p, Oruzje x);
    }
}
