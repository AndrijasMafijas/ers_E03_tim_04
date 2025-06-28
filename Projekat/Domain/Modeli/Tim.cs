using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modeli
{
    public class Tim
    {
        public string nazivTima { get; set; } = string.Empty;

        public int brojHeroja { get; set; } = 0;

        public List<Heroj> listaHeroja { get; set; } = new List<Heroj>();

        public Tim () { }

        public Tim (string nazivTima, int brojHeroja, List<Heroj> listaHeroja)
        {
            this.nazivTima = nazivTima;
            this.brojHeroja = brojHeroja;
            this.listaHeroja = listaHeroja;
        }
    }
}
