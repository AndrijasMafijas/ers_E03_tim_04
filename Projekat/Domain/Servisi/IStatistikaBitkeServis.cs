using Domain.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servisi
{
    public interface IStatistikaBitkeServis
    {
        string IspisiNaEkran(string nazivMape, int idProdavnice);
        public void IspisiUDatoteku(
                string nazivMape,
                int idProdavnice,
                string putanjaDoFajla);
    }
}
