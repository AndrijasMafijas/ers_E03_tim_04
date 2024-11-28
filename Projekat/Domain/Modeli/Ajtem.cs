using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modeli
{
    public abstract class Ajtem
    {
        public int cena { get; set; } = 0;
        public int pojacanjeNapada { get; set; } = 0;
        public int dostupnoZaKupovinu { get; set; } = 0;
        public Ajtem(int cena, int pojacanjeNapada, int dostupnoZaKupovinu)
        {
            this.cena = cena;
            this.pojacanjeNapada = pojacanjeNapada;
            this.dostupnoZaKupovinu = dostupnoZaKupovinu;
        }
    }
}
