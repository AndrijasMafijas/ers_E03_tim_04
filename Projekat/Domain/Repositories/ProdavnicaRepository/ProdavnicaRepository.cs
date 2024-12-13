using Domain.Modeli;

namespace Domain.Repositories.ProdavnicaRepository
{
    public class ProdavnicaRepository : IProdavnicaRepository
    {
        public static List<Prodavnica> Prodavnice { get; set; } = new List<Prodavnica>();
        public ProdavnicaRepository()
        {
            Prodavnice = new List<Prodavnica>();
        }

        public static bool DodajProdavnicu(Prodavnica prodavnica)
        {
            if (prodavnica is not Prodavnica)
                return false;
            foreach (Prodavnica p in Prodavnice)
            {
                if (prodavnica.ID == p.ID)
                    return false;
            }
            Prodavnice.Add(prodavnica);
            return true;
        }
    }
}
