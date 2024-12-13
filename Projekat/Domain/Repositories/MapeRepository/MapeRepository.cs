using Domain.Modeli;

namespace Domain.Repositories.MapeRepository
{
    public class MapeRepository : IMapeRepository
    {
        public static List<Mapa> Mape { get; set; } = new List<Mapa>();

        public MapeRepository()
        {
            Mape = new List<Mapa>();
        }

        public static bool DodajMapu(Mapa map)
        {
            if (map is not Mapa)
                return false;
            foreach (Mapa m in Mape)
            {
                if (m.NazivMape == map.NazivMape)
                    return false;
            }
            Mape.Add(map);
            return true;
        }
    }
}
