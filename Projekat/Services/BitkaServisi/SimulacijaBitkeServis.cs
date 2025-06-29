using Domain.PomocneMetode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BitkaServisi
{
    public class SimulacijaBitkeServis
    {
        public int GenerisiVremeTrajanjaBitke()
        {
            return GeneratorDuzineTrajanjaBitke.GenerisiDuzinuTrajanjaBitke();
        }
    }
}
