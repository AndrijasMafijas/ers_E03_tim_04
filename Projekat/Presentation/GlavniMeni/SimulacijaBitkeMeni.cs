using Domain.Servisi;
using Services.BitkaServisi;
using Services.ProdavnicaServisi;
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
            IAutomatskaKupovinaServis aks = new AutomatskaKupovinaServis();
            IEliminacijaServis es = new EliminacijaServis();
            IProveraKrajaBitkeServis ipkbs = new ProveraKrajaBitkeServis();
            ISimulacijaBitkeServis sbs = new SimulacijaBitkeServis(aks,es,ipkbs);
            int duzinaTrajanjaBitke = sbs.GenerisiVremeTrajanjaBitke();
            Console.WriteLine("Now the battle will begin!");
            float duzinaTB = Convert.ToSingle(duzinaTrajanjaBitke);
            //ovo predstavlja koliko dogadjaja ce se desiti maksimalno u toku borbe
            for (int i = 0; i < 10; i++)
            {
                string ivent = sbs.SimulirajDogadjaj(duzinaTB, IdProdavnice, IdMape);
                Console.WriteLine(ivent);
                if (ivent.Contains("\n---------------Match Finished----------------\nBLUE TEAM WON!!!\n") ||
                    ivent.Contains("\n---------------Match Finished----------------\nRED TEAM WON!!!\n"))
                break;
                
            }
            Console.WriteLine("Kraj!");
        }
    }
}
