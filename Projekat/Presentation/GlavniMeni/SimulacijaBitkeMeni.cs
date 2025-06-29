using Services.BitkaServisi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.GlavniMeni
{
    public class SimulacijaBitkeMeni
    {
        public static void PokreniSimulacijuBitke()
        {
            SimulacijaBitkeServis sbs = new SimulacijaBitkeServis();
            int duzinaTrajanjaBitke = sbs.GenerisiVremeTrajanjaBitke();
            Console.WriteLine("Now the battle will begin and it will last for " + duzinaTrajanjaBitke + " seconds.");
        }
    }
}
