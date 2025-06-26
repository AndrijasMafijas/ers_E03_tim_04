using Domain.Modeli;
using Domain.Servisi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProdavnicaServisi
{
    public class NapitakServis : Domain.Servisi.INapitakServis
    {
        public IEnumerable<Napitak> getListaNapitaka(Prodavnica p)
        {
            return p.listaNapitaka;
        }
        public bool DodajNapitak(Prodavnica p, Napitak x)
        {
            if (x is not Napitak)
            {
                return false;
            }
            foreach (Napitak y in p.listaNapitaka)
            {
                if (x.NazivNapitka == y.NazivNapitka)
                {
                    return false;
                }
            }
            p.listaNapitaka.Add(x);
            return true;
        }
    }
}
