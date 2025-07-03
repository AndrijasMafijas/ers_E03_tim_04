using Domain.Modeli;
using Domain.Repositories.MapeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PomocneMetode
{
    public class PronadjiMapu
    {
        static IMapeRepository mapeRepository = new MapeRepository();
        public static Mapa PronadjiMapuPoNazivu(string ime)
        {
            return mapeRepository.PronadjiMapuPoNazivu(ime);
        }
    }
}
