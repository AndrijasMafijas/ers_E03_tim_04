using Domain.Modeli;

namespace Domain.Repositories.MapeRepository
{
    public class MapeRepository : IMapeRepository
    {
        public static List<Mapa> Mape { get; set; } = new List<Mapa>();

        static MapeRepository()
        {
            Mape = new List<Mapa>
            {
                new Mapa("Test",Enumeracija.Tip_Mape.LETNJA,10,"Orlovi","Tigrovi",10)
            };
        }

        public bool DodajMapu(Mapa map)
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

        public Mapa PronadjiMapuPoNazivu(string nazivMape)
        {
            foreach (Mapa m in Mape) {
                if (m.NazivMape == nazivMape) return m;
            }
            return new Mapa();
        }
    }
}
