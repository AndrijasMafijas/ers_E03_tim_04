using Domain.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servisi
{
    public interface IProdavnicaServis
    {
        public IEnumerable<Oruzje> getListaOruzja(Prodavnica p);
        public IEnumerable<Napitak> getListaNapitaka(Prodavnica p);
        public bool DodajOruzje(Prodavnica p, Oruzje x);
        public bool DodajNapitak(Prodavnica p, Napitak x);
    }
}
