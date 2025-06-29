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
        private static List<Guid> PikovaniHeroji { get; set; } = new List<Guid>();

        public TimoviRepository() { }
        public bool DodajUPlaviTim(Igrac x)
        {
            foreach (Igrac p in PlaviTim)
            {
                if (p.getIme() == x.getIme() || p.getIdHeroja() == x.getIdHeroja()) return false;
            }
            PlaviTim.Add(x);
            PikovaniHeroji.Add(x.getIdHeroja());
            return true;
        }

        public bool PronadjiHeroja(Guid x)
        {
            foreach(Guid g in PikovaniHeroji)
            {
                if(g == x) return true;
            }
            return false;
        }

        public bool DodajUCrveniTim(Igrac x)
        {
            foreach (Igrac p in CrveniTim)
            {
                if (p.getIme() == x.getIme() || p.getIdHeroja() == x.getIdHeroja()) return false;
            }
            CrveniTim.Add(x);
            PikovaniHeroji.Add(x.getIdHeroja());
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

        public bool UkloniIgraca(Guid x)
        {
            foreach(Igrac p in CrveniTim)
            {
                if(p.getIdHeroja() == x)
                {
                    CrveniTim.Remove(p);
                    return true;
                }
            }
            foreach(Igrac p in PlaviTim)
            {
                if(p.getIdHeroja() == x)
                {
                    PlaviTim.Remove(p);
                    return true;
                }
            }
            return false;
        }
    }
}
