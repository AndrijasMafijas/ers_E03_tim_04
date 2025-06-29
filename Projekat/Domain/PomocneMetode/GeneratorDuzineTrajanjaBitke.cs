using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PomocneMetode
{
    public class GeneratorDuzineTrajanjaBitke
    {
        public static int GenerisiDuzinuTrajanjaBitke()
        {
            Random random = new Random();
            return (int)random.NextInt64(10, 45);
        }
    }
}
