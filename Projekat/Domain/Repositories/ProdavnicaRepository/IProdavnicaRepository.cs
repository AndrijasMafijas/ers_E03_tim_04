using Domain.Modeli;

namespace Domain.Repositories.ProdavnicaRepository
{
    public interface IProdavnicaRepository
    {
        bool DodajProdavnicu(Prodavnica prodavnica);
        Prodavnica PronadjiProdavnicuPoIdu(int id);
    }
}
