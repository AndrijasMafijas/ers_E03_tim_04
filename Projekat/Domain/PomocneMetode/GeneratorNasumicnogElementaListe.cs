using Domain.Modeli;
using Domain.Repositories.HerojiRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PomocneMetode
{
    public class GeneratorNasumicnogElementaListe
    {
        static IHerojiRepository heroji = new HerojiRepository();
        public static Igrac OdaberiNasumicnogZivogIgraca(List<Igrac> lista)
        {
            while (true)
            {
                Random rnd = new Random();
                int index = rnd.Next(lista.Count);
                Heroj h = heroji.PronadjiPoId(lista[index].getIdHeroja());
                if (!h.JelMrtav)
                    return lista[index];
                else continue;
            }
        }
        public static Napitak OdaberiNasumicniNapitak(List<Napitak> lista)
        {
            Random rnd = new Random();
            int index = rnd.Next(lista.Count);
            return lista[index];
        }
        public static Oruzje OdaberiNasumicnoOruzje(List<Oruzje> lista)
        {
            Random rnd = new Random();
            int index = rnd.Next(lista.Count);
            return lista[index];
        }
    }
}
