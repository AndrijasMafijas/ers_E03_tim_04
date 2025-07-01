using System;
using Domain.Enumeracija;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modeli
{
	public class Oruzje : Ajtem
	{
        public string NazivOruzja { get; set; } = string.Empty;

        public Oruzje(string NazivOruzja, int Cena, int PojacanjeNapada, int DostupnoZaKupovinu) : base(Cena, PojacanjeNapada,DostupnoZaKupovinu)
        {
            this.NazivOruzja = NazivOruzja;
        }
	}
}
