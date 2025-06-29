using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PomocneMetode
{
    public class GeneratorOpcija
    {
        public GeneratorOpcija() { }
        public static int GenerisiOpciju()
        {
            Random random = new Random();
            return random.Next(1,3);
        }

    }
}
