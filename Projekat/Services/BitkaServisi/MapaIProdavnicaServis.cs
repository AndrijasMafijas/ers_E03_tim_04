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
    public class MapaIProdavnicaServis
    {
        public MapaIProdavnicaServis() { }
        public Mapa PronadjiMapu(string ime)
        {
            IMapeRepository mapeRepository = new MapeRepository();
            return mapeRepository.PronadjiMapuPoNazivu(ime);
        }
        public Prodavnica PronadjiProdavnicu(int id)
        {
            IProdavnicaRepository prodavnicaRepository = new ProdavnicaRepository();
            return prodavnicaRepository.PronadjiProdavnicuPoIdu(id);
        }
    }
}
