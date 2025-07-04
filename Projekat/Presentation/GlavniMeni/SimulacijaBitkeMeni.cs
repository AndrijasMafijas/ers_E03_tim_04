using Domain.Servisi;
using Services.BitkaServisi;
using Services.ProdavnicaServisi;
using System;

namespace Presentation.GlavniMeni
{
    public class SimulacijaBitkeMeni
    {
        public static void PokreniSimulacijuBitke(int IdProdavnice, string IdMape)
        {
            IAutomatskaKupovinaServis aks = new AutomatskaKupovinaServis();
            IEliminacijaServis es = new EliminacijaServis();
            IProveraKrajaBitkeServis ipkbs = new ProveraKrajaBitkeServis();
            ISimulacijaBitkeServis sbs = new SimulacijaBitkeServis(aks, es, ipkbs);

            int duzinaTrajanjaBitke = sbs.GenerisiVremeTrajanjaBitke();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n****************************************");
            Console.WriteLine("         NOW THE BATTLE WILL BEGIN!      ");
            Console.WriteLine("****************************************\n");
            Console.ResetColor();

            float duzinaTB = Convert.ToSingle(duzinaTrajanjaBitke);

            for (int i = 0; i < 15; i++)
            {
                string ivent = sbs.SimulirajDogadjaj(duzinaTB, IdProdavnice, IdMape);

                // Proveri odmah da li je utakmica završena
                if (ivent.Contains("MATCH FINISHED"))
                {
                    // Ispiši događaj i odmah prekini
                    Console.ForegroundColor = ivent.Contains("BLUE TEAM WON") ? ConsoleColor.Blue : ConsoleColor.Red;
                    Console.WriteLine(ivent);
                    Console.ResetColor();
                    break;
                }

                foreach (var line in ivent.Split('\n', StringSplitOptions.RemoveEmptyEntries))
                {
                    if (line.Contains("eliminated") || line.Contains("gained") || line.Contains("damaged"))
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ResetColor();

                    Console.WriteLine(line);
                }

                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n=== END OF THE BATTLE ===\n");
            Console.ResetColor();
        }
    }
}
