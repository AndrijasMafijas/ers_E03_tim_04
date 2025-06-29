using Domain.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PomocneMetode
{
    public class GeneratorNasumicnogElementaListe
    {
        public static Igrac OdaberiNasumicnogIgraca(List<Igrac> lista)
        {
            Random rnd = new Random();
            int index = rnd.Next(lista.Count);
            return lista[index];
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
