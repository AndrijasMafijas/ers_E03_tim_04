using Domain.Enumeracija;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modeli
{
	public class Napitak : Ajtem
	{
		public string NazivNapitka { get; set; } = string.Empty;

		public Napitak(string NazivNapitka,int Cena,int PojacanjeNapada,int DostupnoZaKupovinu) : base(Cena,PojacanjeNapada,DostupnoZaKupovinu)
		{
			this.NazivNapitka = NazivNapitka;
		}

	}
}
