using Domain.Modeli;
using Domain.Repositories.ProdavnicaRepository;
using Domain.Servisi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProdavnicaServisi
{
    public class OdabirProdavniceServis : IOdabirProdavniceServis
    {
        IProdavnicaRepository prodavnicaRepository = new ProdavnicaRepository();
        public Prodavnica PronadjiProdavnicu(int id)
        {
            return prodavnicaRepository.PronadjiProdavnicuPoIdu(id);
        }
    }
}
