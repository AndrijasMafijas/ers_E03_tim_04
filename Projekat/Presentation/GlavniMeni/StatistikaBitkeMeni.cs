using Domain.Servisi;
using Services.BitkaServisi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.GlavniMeni
{
    public class StatistikaBitkeMeni
    {
        public static void StatistikaBitke(int idProdavnice, string nazivMape)
        {
            bool dobarUnos = false;
            IStatistikaBitkeServis sbs = new StatistikaBitkeServis();
            Console.WriteLine("\nThe battle is over , please enter 1 if you want to see statistics in this window or 2 if you want to see it in txt file.");
            while (!dobarUnos)
            {
                string x = Console.ReadLine();
                if(x != "1" && x != "2")
                {
                    Console.WriteLine("Please enter a 1 or 2 only!");
                    continue;
                }
                dobarUnos = true;
                if(x == "1")
                {
                    string ispis = sbs.IspisiStatistikuBitke(idProdavnice, nazivMape);
                    Console.WriteLine(ispis);
                }
                else
                {
                    Console.WriteLine("Please enter the name of txt file you would like to save statistics in: ");
                    string NazivDatoteke = Console.ReadLine();
                    if(NazivDatoteke == string.Empty)
                    {
                        Console.WriteLine("\nName of txt file is not valid!");
                        continue;
                    }
                    sbs.IspisiUDatoteku(NazivDatoteke);
                }
            }
        }
    }
}
