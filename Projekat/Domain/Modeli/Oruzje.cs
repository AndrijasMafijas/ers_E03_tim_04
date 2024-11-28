using System;
using Domain.Enumeracija;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modeli
{
	public class Oruzje
	{
        public string nazivOruzja { get; set; } = string.Empty;
        public int cena { get; set; } = 0;
        public int pojacanjeNapada { get; set; } = 0;
        public int dostupnoZaKupovinu { get; set; } = 0;

        public Oruzje(string NazivOruzja, int Cena, int PojacanjeNapada, int DostupnoZaKupovinu)
        {
            nazivOruzja = NazivOruzja;
            cena = Cena;
            pojacanjeNapada = PojacanjeNapada;
            dostupnoZaKupovinu = DostupnoZaKupovinu;
        }

        public Oruzje() { }
	}
}
