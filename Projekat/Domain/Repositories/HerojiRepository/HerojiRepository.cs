using Domain.Modeli;

namespace Domain.Repositories.HerojiRepository
{
    public class HerojiRepository : IHerojiRepository
    {
        private static List<Heroj> Heroji { get; set; } = new List<Heroj>();

        static HerojiRepository()
        {
            Heroji = new List<Heroj>()
            {
                new Heroj("Veliki Čarobnjak Emil",60,90,0)
            };
        }

        public Heroj PronadjiPoId(Guid guid)
        {
            Heroj? heroj= Heroji.FirstOrDefault((h) => (h.Id == guid));
            if (heroj == null)
            {
                return new Heroj();
            }
            else { 
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
            if(heroj.NazivHeroja == string.Empty) return false;
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
