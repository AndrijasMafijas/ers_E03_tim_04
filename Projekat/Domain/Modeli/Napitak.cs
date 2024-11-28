using Domain.Enumeracija;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modeli
{
	public class Napitak
	{
		public string nazivNapitka { get; set; } = string.Empty;
		public int cena { get; set; } = 0;
		public int pojacanjeNapada { get; set; } = 0;
		public int dostupnoZaKupovinu { get; set; } = 0;

		public Napitak() {	}

		public Napitak(string NazivNapitka,int Cena,int PojacanjeNapada,int DostupnoZaKupovinu)
		{
			nazivNapitka = NazivNapitka;
			cena = Cena;
			pojacanjeNapada = PojacanjeNapada;
			dostupnoZaKupovinu = DostupnoZaKupovinu;
		}

	}
}
