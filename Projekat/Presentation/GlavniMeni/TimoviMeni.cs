using Domain.Modeli;
using Domain.Servisi;
using Services.BitkaServisi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.GlavniMeni
{
    public class TimoviMeni
    {
        public TimoviMeni() { }

        public static void DodavanjeIgraca()
        {
            bool dobarUnos = false;
            int brojka = 0;
            while (!dobarUnos) {
                Console.WriteLine("Please enter how many players will each team contain: (bettwen 1 and 5)");
                string broj = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(broj) || !int.TryParse(broj, out brojka) || int.Parse(broj) > 5 || int.Parse(broj) < 1) continue;
                dobarUnos = true;
            }
            dobarUnos = false;
            //dodavanje u plavi tim
            ITimoviServis ts = new TimoviServis();
            Console.WriteLine(ts.IspisiListuHeroja());
            Console.WriteLine("\nNow you are entering names and heroes for team blue: \n");
            for(int i = 0; i < brojka; )
            {
                Console.WriteLine((i+1) + ". player name: ");
                string imeIgraca = Console.ReadLine();
                if(string.IsNullOrWhiteSpace(imeIgraca) || imeIgraca.Length > 15)
                {
                    Console.WriteLine("Name must be valid");
                    continue;
                }
                Console.WriteLine((i+1) + " hero: ");
                string imeHeroja = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(imeHeroja))
                {
                    Console.WriteLine("Must enter a valid hero name");
                    continue;
                }
                Guid idHeroja = ts.PronadjiHeroja(imeHeroja);
                if(idHeroja == Guid.Empty)
                {
                    Console.WriteLine("Must enter an existing hero name");
                    continue;
                }
                if(ts.PronadjiHeroja(idHeroja))
                {
                    Console.WriteLine("That hero is already picked by another player");
                    continue;
                }
                ts.DodavanjeIgracaUPlaviTim(new Igrac(imeIgraca, idHeroja));
                i++;
            }

            //dodavanje u crveni tim
            Console.WriteLine("\nNow you are entering names and heroes for team red: \n");
            Console.WriteLine(ts.IspisiListuHeroja());
            for (int i = 0; i < brojka;)
            {
                Console.WriteLine((i + 1) + ". player name: ");
                string imeIgraca = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(imeIgraca) || imeIgraca.Length > 15)
                {
                    Console.WriteLine("Name must be valid");
                    continue;
                }
                Console.WriteLine((i+1) +" hero: ");
                string imeHeroja = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(imeHeroja))
                {
                    Console.WriteLine("Must enter a valid hero name");
                    continue;
                }
                Guid idHeroja = ts.PronadjiHeroja(imeHeroja);
                if (idHeroja == Guid.Empty)
                {
                    Console.WriteLine("Must enter an existing hero name");
                    continue;
                }
                if (ts.PronadjiHeroja(idHeroja))
                {
                    Console.WriteLine("That hero is already picked by another player");
                    continue;
                }
                ts.DodavanjeIgracaUCrveniTim(new Igrac(imeIgraca, idHeroja));
                i++;
            }
        }
    }
}
