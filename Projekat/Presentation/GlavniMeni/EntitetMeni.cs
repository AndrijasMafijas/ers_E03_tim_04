using Domain.PomocneMetode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.GlavniMeni
{
    public class EntitetMeni
    {
        EntitetMeni() { }
        public static int OdabirEntiteta()
        {
            bool dobarOdabir = false;
            while (!dobarOdabir) {
                Console.WriteLine("Enter 1 to manually enter entities, or 2 to generate them automatically.");
                string linija = Console.ReadLine();
                int odabir;
                if (!string.IsNullOrWhiteSpace(linija) && int.TryParse(linija , out odabir))
                {
                    if (odabir == 1 || odabir == 2)
                    {
                        dobarOdabir = true;
                        if (odabir == 2)
                        {
                            int brojka = GeneratorEntiteta.GenerisiBrojEntiteta();
                            Console.WriteLine("Randomly generated " + brojka + " entities.");
                            return brojka;
                        }
                        else
                        {
                            while (true)
                            {
                                Console.WriteLine("Please enter number of entities: (bettwen 1 and 10)");
                                string linijaa = Console.ReadLine();
                                int brojEntiteta;
                                if (string.IsNullOrWhiteSpace(linijaa) || !int.TryParse(linijaa , out brojEntiteta)|| Convert.ToInt32(linijaa) < 1 || Convert.ToInt32(linijaa) > 10) continue;
                                return brojEntiteta;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter just 1 or 2");
                    }
                }
            }
            return 0;
        }
    }
}
