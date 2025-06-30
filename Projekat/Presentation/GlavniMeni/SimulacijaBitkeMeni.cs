using Domain.Servisi;
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
            ISimulacijaBitkeServis sbs = new SimulacijaBitkeServis();
            int duzinaTrajanjaBitke = sbs.GenerisiVremeTrajanjaBitke();
            Console.WriteLine("Now the battle will begin!");
            float duzinaTB = Convert.ToSingle(duzinaTrajanjaBitke);
            //ovo predstavlja koliko dogadjaja ce se desiti maksimalno u toku borbe
            for(int i=0;i<5;i++)
            Console.WriteLine(sbs.SimulirajDogadjaj(duzinaTB, IdProdavnice, IdMape));

            Console.WriteLine("Kraj!");
        }
    }
}
