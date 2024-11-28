using Domain.Servisi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modeli
{
    public class Prodavnica : IProdavnica
    {
        public int id { get; set; } = 0;
        public List<Oruzje> listaOruzja { get; set; } 
        public List<Napitak> listaNapitaka { get; set; } 
        public int ukupanPrihod { get; set; } = 0;

        public Prodavnica() 
        {
            listaOruzja = new List<Oruzje>();
            listaNapitaka = new List<Napitak>();
        }

        public Prodavnica(int Id,List<Oruzje> x,List<Napitak> y,int UkupanPrihod)
        {
            id = Id;
            listaOruzja = x;
            listaNapitaka = y;
            ukupanPrihod = UkupanPrihod;
        }

        public bool DodajOruzje(Oruzje x)
        { 
            if(x is not Oruzje)
            {
                return false;
            }
            foreach(Oruzje y in listaOruzja)
            {
                if(x.nazivOruzja == y.nazivOruzja)
                {
                    return false;
                }
            }
            listaOruzja.Add(x);
            return true;
        }

        public bool DodajNapitak(Napitak x)
        {
            if (x is not Napitak)
            {
                return false;
            }
            foreach (Napitak y in listaNapitaka)
            {
                if (x.nazivNapitka == y.nazivNapitka)
                {
                    return false;
                }
            }
            listaNapitaka.Add(x);
            return true;
        }
    }
}
