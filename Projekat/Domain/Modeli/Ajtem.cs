using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modeli
{
    public abstract class Ajtem
    {
        public int Cena { get; set; } = 0;
        public int PojacanjeNapada { get; set; } = 0;
        public int DostupnoZaKupovinu { get; set; } = 0;
        public Ajtem(int cena, int pojacanjeNapada, int dostupnoZaKupovinu)
        {
            this.Cena = cena;
            this.PojacanjeNapada = pojacanjeNapada;
            this.DostupnoZaKupovinu = dostupnoZaKupovinu;
        }
    }
}
