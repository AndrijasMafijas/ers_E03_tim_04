using Domain.Modeli;
using Domain.Servisi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.Services
{
    public class ProdavnicaServis : IProdavnicaServis
    {
        public IEnumerable<Oruzje> getListaOruzja(Prodavnica p)
        {
            return p.listaOruzja;
        }

        public IEnumerable<Napitak> getListaNapitaka(Prodavnica p)
        {
            return p.listaNapitaka;
        }
        public bool DodajOruzje(Prodavnica p, Oruzje x)
        {
            if (x is not Oruzje)
            {
                return false;
            }
            foreach (Oruzje y in p.listaOruzja)
            {
                if (x.nazivOruzja == y.nazivOruzja)
                {
                    return false;
                }
            }
            p.listaOruzja.Add(x);
            return true;
        }

        public bool DodajNapitak(Prodavnica p, Napitak x)
        {
            if (x is not Napitak)
            {
                return false;
            }
            foreach (Napitak y in p.listaNapitaka)
            {
                if (x.nazivNapitka == y.nazivNapitka)
                {
                    return false;
                }
            }
            p.listaNapitaka.Add(x);
            return true;
        }
    }
}
