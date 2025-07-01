using Domain.Modeli;
using Domain.Servisi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProdavnicaServisi
{
    public class OruzjeServis : IOruzjeServis
    {
        public IEnumerable<Oruzje> getListaOruzja(Prodavnica p)
        {
            return p.ListaOruzja;
        }
        public bool DodajOruzje(Prodavnica p, Oruzje x)
        {
            if (x is not Oruzje)
            {
                return false;
            }
            foreach (Oruzje y in p.ListaOruzja)
            {
                if (x.NazivOruzja == y.NazivOruzja)
                {
                    return false;
                }
            }
            p.ListaOruzja.Add(x);
            return true;
        }
    }
}
