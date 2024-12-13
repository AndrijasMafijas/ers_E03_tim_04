using Domain.Modeli;

namespace Domain.Repositories.HerojiRepository
{
    public class HerojiRepository : IHerojiRepository
    {
        public static List<Heroj> Heroji { get; set; } = new List<Heroj>();

        public HerojiRepository()
        {
            Heroji = new List<Heroj>();
        }

        public static bool DodajHeroja(Heroj heroj)
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

        public static bool UkloniHeroja(Heroj heroj)
        {
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
