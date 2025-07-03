using Domain.Modeli;
using Domain.Repositories.ProdavnicaRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PomocneMetode
{
    public class PronadjiProdavnicu
    {
        static IProdavnicaRepository prodavnicaRepository = new ProdavnicaRepository();
        public static Prodavnica PronadjiProdavnicuPoIdu(int id)
        {
            return prodavnicaRepository.PronadjiProdavnicuPoIdu(id);
        }
    }
}
