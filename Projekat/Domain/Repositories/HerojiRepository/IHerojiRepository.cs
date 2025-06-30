using Domain.Modeli;

namespace Domain.Repositories.HerojiRepository
{
    public interface IHerojiRepository
    {
        public bool DodajHeroja(Heroj heroj);
        public bool HerojUbijen(Guid heroj);
        public Heroj PronadjiPoId(Guid guid);
        Heroj PronadjiPoImenu(string x);
        public string IspisiListu();

        public List<Heroj> VratiSveHeroje();
    }
}
