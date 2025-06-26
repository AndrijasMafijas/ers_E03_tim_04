using Domain.Modeli;

namespace Domain.Repositories.MapeRepository
{
    public interface IMapeRepository
    {
        bool DodajMapu(Mapa map);
        Mapa PronadjiMapuPoNazivu(string nazivMape);
    }
}
