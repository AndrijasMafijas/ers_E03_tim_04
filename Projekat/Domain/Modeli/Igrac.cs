using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modeli
{
    public class Igrac
    {
        private string Ime {  get; set; } = string.Empty;
        private Guid IdHeroja { get; set; }
        public Igrac() { }

        public Igrac(string ime, Guid idHeroja)
        {
            this.Ime = ime;
            this.IdHeroja = idHeroja;
        }

        public string getIme()
        {
            return Ime;
        }
        public Guid getIdHeroja()
        {
            return IdHeroja;
        }


    }
}
