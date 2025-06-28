using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PomocneMetode
{
    public class GeneratorEntiteta
    {
        
        public static int GenerisiBrojEntiteta()
        {
            Random random = new Random();
            return (int)random.NextInt64(1, 10);
        }
    }
}
