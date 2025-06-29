using Domain.Modeli;
using Domain.Repositories.MapeRepository;
using Domain.Repositories.ProdavnicaRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BitkaServisi
{
    public class OdabirMapeServis
    {
        public OdabirMapeServis() { }
        public Mapa PronadjiMapu(string ime)
        {
            IMapeRepository mapeRepository = new MapeRepository();
            return mapeRepository.PronadjiMapuPoNazivu(ime);
        }
        
    }
}
