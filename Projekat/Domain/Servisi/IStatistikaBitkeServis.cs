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
        public string IspisiStatistikuBitke(int idProdavnice, string nazivMape);

        public void IspisiUDatoteku(
                List<Heroj> crveniTim,
                List<Heroj> plaviTim,
                string nazivMape,
                int idProdavnice,
                string putanjaDoFajla);
    }
}
