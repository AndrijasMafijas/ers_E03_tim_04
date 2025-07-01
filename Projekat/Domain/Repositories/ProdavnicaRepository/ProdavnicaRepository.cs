using Domain.Modeli;
namespace Domain.Repositories.ProdavnicaRepository
{
    public class ProdavnicaRepository : IProdavnicaRepository
    {
        private static List<Prodavnica> Prodavnice { get; set; } = new List<Prodavnica>();
        static ProdavnicaRepository()
        {
            Prodavnice = new List<Prodavnica> {
                new Prodavnica(1,0,new List<Oruzje>
                {
                    new Oruzje("Kundak",100,10,2)
                } , new List<Napitak>
                {
                    new Napitak("Vesticjin otrov",150,17,4)
                })
            };
        }
        public List<Prodavnica> VratiSveProdavnice() => Prodavnice;
        public bool DodajProdavnicu(Prodavnica prodavnica)
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

        public Prodavnica PronadjiProdavnicuPoIdu(int id)
        {
            foreach (Prodavnica p in Prodavnice)
            {
                if (p.ID == id) return p;
            }
            return new Prodavnica();
        }

        public bool prodajOruzje(Oruzje a, int idProdavnice)
        {
            foreach(Prodavnica p in Prodavnice)
            {
                if(p.ID == idProdavnice)
                {
                    foreach(Oruzje o in p.ListaOruzja)
                    {
                        if(o.NazivOruzja == a.NazivOruzja && o.DostupnoZaKupovinu > 0)
                        {
                            o.DostupnoZaKupovinu--;
                            if(o.DostupnoZaKupovinu == 0) p.ListaOruzja.Remove(o);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool prodajNapitak(Napitak a, int idProdavnice)
        {
            foreach (Prodavnica p in Prodavnice)
            {
                if (p.ID == idProdavnice)
                {
                    foreach (Napitak o in p.ListaNapitaka)
                    {
                        if (o.NazivNapitka == a.NazivNapitka && o.DostupnoZaKupovinu > 0)
                        {
                            o.DostupnoZaKupovinu--;
                            if (o.DostupnoZaKupovinu == 0) p.ListaNapitaka.Remove(o);
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
