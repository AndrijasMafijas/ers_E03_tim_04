using Domain.Modeli;

namespace Domain.Repositories.ProdavnicaRepository
{
    public interface IProdavnicaRepository
    {
        bool DodajProdavnicu(Prodavnica prodavnica);
        Prodavnica PronadjiProdavnicuPoIdu(int id);
        public List<Prodavnica> VratiSveProdavnice();
        public bool prodajNapitak(Napitak a, int idProdavnice);
        public bool prodajOruzje(Oruzje a, int idProdavnice);

    }
}
