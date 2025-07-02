using Domain.Modeli;
using System;

namespace Domain.Repositories.HerojiRepository
{
    public class HerojiRepository : IHerojiRepository
    {
        private static List<Heroj> Heroji { get; set; } = new List<Heroj>();

        static HerojiRepository()
        {
            Heroji = new List<Heroj>()
            {
                new Heroj("Garen", 39, 80, 0),
                new Heroj("Darius", 65, 40, 0),
                new Heroj("Jax", 52, 65, 0),
                new Heroj("Ornn", 78, 40, 0),
                new Heroj("Zed", 59, 70, 0),
                new Heroj("Morgana", 46, 75, 0),
                new Heroj("Rex", 72, 30, 0),
                new Heroj("Sylas", 55, 60, 0),
                new Heroj("Kayn", 61, 50, 0),
                new Heroj("Nocturne", 68, 45, 0)
            };
        }
        public List<Heroj> VratiSveHeroje() => Heroji;

        public string IspisiListu()
        {
            string x = "Here is the list of available heroes: \n";
            foreach (Heroj h in Heroji)
            {
                x += h.NazivHeroja + " \n";
            }
            return x;
        }

        public Heroj PronadjiPoId(Guid guid)
        {
            Heroj? heroj = Heroji.FirstOrDefault((h) => (h.Id == guid));
            if (heroj == null)
            {
                return new Heroj();
            }
            else
            {
                return heroj;
            }

        }

        public Heroj PronadjiPoImenu(string x)
        {
            Heroj? heroj = Heroji.FirstOrDefault((h) => (h.NazivHeroja == x));
            if (heroj == null)
            {
                return new Heroj();
            }
            else
            {
                return heroj;
            }
        }
        public bool DodajHeroja(Heroj heroj)
        {
            if (heroj is not Heroj)
            {
                return false;
            }
            foreach (Heroj h in Heroji)
            {
                if (heroj.NazivHeroja == h.NazivHeroja)
                    return false;
            }
            Heroji.Add(heroj);
            return true;
        }
        public bool HerojUbijen(Guid IdHeroja)
        {
            Heroj heroj = PronadjiPoId(IdHeroja);
            if (heroj.NazivHeroja == string.Empty) return false;
            if (heroj.NazivHeroja == string.Empty)
            {
                return false;
            }
            heroj.JelMrtav = true;
            heroj.ZivotniPoeni = 0;
            return true;
        }
    }
}
