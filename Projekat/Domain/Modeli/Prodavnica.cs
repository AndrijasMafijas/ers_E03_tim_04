using Domain.Servisi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modeli
{
    public class Prodavnica
    {
        public int ID { get; set; } = 0;
        public int UkupnoProdato { get; set; } = 0;
        public List<Oruzje> ListaOruzja { get; set; } = new List<Oruzje>();
        public List<Napitak> ListaNapitaka { get; set; } = new List<Napitak>();

        public Prodavnica()
        {
            ID = 0;
            UkupnoProdato = 0;
            ListaOruzja = new List<Oruzje>();
            ListaNapitaka = new List<Napitak>();
        }

        public Prodavnica(int id,int ukpnoProdato,List<Oruzje> listaOruzjaa, List<Napitak> listaNapitakaa)
        {
            ID = id;
            UkupnoProdato= ukpnoProdato;
            ListaOruzja = listaOruzjaa;
            ListaNapitaka = listaNapitakaa;
        }
    }
}
