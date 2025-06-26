using Domain.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servisi
{
    public interface INapitakServis
    {
        public IEnumerable<Napitak> getListaNapitaka(Prodavnica p);
        public bool DodajNapitak(Prodavnica p, Napitak x);
    }
}
