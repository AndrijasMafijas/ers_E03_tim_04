using Domain.Enumeracija;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modeli
{
    public class Mapa
    {
        public string NazivMape {  get; set; } = string.Empty;
        public Tip_Mape Tip_Mape { get; set; }
        public int MaksimalanBrojIgraca { get; set; } = 0;
        public string NazivCrvenih {  get; set; } = string.Empty;   
        public string NazivPlavih {  get; set; } = string.Empty;
        public int BrojPomocnih { get; set; } = 0;

        public Mapa() { }

        public Mapa (string nazivMape, Tip_Mape tip_Mape, int maksimalanBrojIgraca, string nazivCrvenih, string nazivPlavih, int brojPomocnih)
        {
            NazivMape = nazivMape;
            Tip_Mape = tip_Mape;
            MaksimalanBrojIgraca = maksimalanBrojIgraca;
            NazivCrvenih = nazivCrvenih;
            NazivPlavih = nazivPlavih;
            BrojPomocnih = brojPomocnih;
        }
    }
}
