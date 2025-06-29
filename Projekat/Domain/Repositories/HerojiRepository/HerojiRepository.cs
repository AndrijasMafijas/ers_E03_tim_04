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
                new Heroj("Veliki Carobnjak Emil", 60, 90, 0),
                new Heroj("Ratnik Srebrne Senke", 100, 40, 0),
                new Heroj("Lovac iz Trnave", 80, 60, 0),
                new Heroj("Gvozdeni Vitez", 120, 30, 0),
                new Heroj("Zmajcar Zara", 90, 70, 0),
                new Heroj("Sumska Vestica Radojka", 70, 100, 0),
                new Heroj("Vuk Samotnjak", 110, 20, 0),
                new Heroj("Gospodar Oluje", 85, 95, 0),
                new Heroj("Krvavi Osvetnik", 95, 50, 0),
                new Heroj("Nocni Strazar", 105, 45, 0)
            };
        }

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

        public bool UkloniHeroja(Guid IdHeroja)
        {
            Heroj heroj = PronadjiPoId(IdHeroja);
            if (heroj.NazivHeroja == string.Empty) return false;
            bool postoji = false;
            if (heroj is not Heroj)
            {
                return false;
            }
            foreach (Heroj h in Heroji)
            {
                if (h.NazivHeroja == heroj.NazivHeroja)
                    postoji = true;
            }
            if (postoji)
            {
                Heroji.Remove(heroj);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
