using Domain.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.TimoviRepository
{
    public class TimoviRepository : ITimoviRepository
    {
        private static List<Igrac> PlaviTim { get; set; } = new List<Igrac>();
        private static List<Igrac> CrveniTim { get; set; } = new List<Igrac>();

        public TimoviRepository() { }
        public bool DodajUPlaviTim(Igrac x)
        {
            foreach (Igrac p in PlaviTim)
            {
                if (p.getIme() == x.getIme() || p.getIdHeroja() == x.getIdHeroja()) return false;
            }
            PlaviTim.Add(x);
            return true;
        }

        public bool DodajUCrveniTim(Igrac x)
        {
            foreach (Igrac p in CrveniTim)
            {
                if (p.getIme() == x.getIme() || p.getIdHeroja() == x.getIdHeroja()) return false;
            }
            CrveniTim.Add(x);
            return true;
        }

        public List<Igrac> getCrveniTim()
        {
            return CrveniTim;
        }

        public List<Igrac> getPlaviTim()
        {
            return PlaviTim;
        }
    }
}
