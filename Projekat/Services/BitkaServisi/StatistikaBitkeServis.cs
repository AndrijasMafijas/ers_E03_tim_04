using Domain.Modeli;
using Domain.Repositories.HerojiRepository;
using Domain.Repositories.MapeRepository;
using Domain.Repositories.ProdavnicaRepository;
using Domain.Repositories.TimoviRepository;
using Domain.Servisi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BitkaServisi
{
    public class StatistikaBitkeServis : IStatistikaBitkeServis
    {
        IGeneratorStatistikeBitkeServis gsb;
        public StatistikaBitkeServis(IGeneratorStatistikeBitkeServis gsb)
        {
            this.gsb = gsb;
        }
        public string IspisiNaEkran(string nazivMape, int idProdavnice)
        {
            return gsb.IspisiStatistikuBitke(idProdavnice, nazivMape);
        }
        public void IspisiUDatoteku(
            string nazivMape,
            int idProdavnice,
            string imeFaila)
        {
            File.WriteAllText(imeFaila, gsb.IspisiStatistikuBitke(idProdavnice, nazivMape));
        }
    
    }
}
