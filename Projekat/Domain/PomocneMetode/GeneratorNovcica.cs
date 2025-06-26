using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PomocneMetode
{
    public  class GeneratorNovcica
    {
        
        public static int EliminacijaEntiteta()
        {
            Random random = new Random();
            return (int)random.NextInt64(20, 90);
        }
    }
}
