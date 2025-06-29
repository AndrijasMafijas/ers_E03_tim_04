using Domain.Modeli;
using Domain.Repositories.ProdavnicaRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProdavnicaServisi
{
    public class OdabirProdavniceServis
    {
        public Prodavnica PronadjiProdavnicu(int id)
        {
            IProdavnicaRepository prodavnicaRepository = new ProdavnicaRepository();
            return prodavnicaRepository.PronadjiProdavnicuPoIdu(id);
        }
    }
}
