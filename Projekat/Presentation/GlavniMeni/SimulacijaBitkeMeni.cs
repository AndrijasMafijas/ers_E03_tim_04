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
        public static void PokreniSimulacijuBitke(int IdProdavnice, string IdMape)
        {
            SimulacijaBitkeServis sbs = new SimulacijaBitkeServis();
            int duzinaTrajanjaBitke = sbs.GenerisiVremeTrajanjaBitke();
            Console.WriteLine("Now the battle will begin!");
            float duzinaTB = Convert.ToSingle(duzinaTrajanjaBitke);
            Console.WriteLine(sbs.SimulirajDogadjaj(duzinaTB, IdProdavnice, IdMape));

            Console.WriteLine("Kraj!");
        }
    }
}
