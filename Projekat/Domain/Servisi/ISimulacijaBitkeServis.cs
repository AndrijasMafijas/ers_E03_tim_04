using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servisi
{
    public interface ISimulacijaBitkeServis
    {
        public int GenerisiVremeTrajanjaBitke();

        public string SimulirajDogadjaj(float duzinaTB, int IdProdavnice, string nazivMape);
    }
}
