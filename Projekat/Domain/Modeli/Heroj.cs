using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modeli
{
    public class Heroj
    {

        public string NazivHeroja { get; set; } = string.Empty;
        public Guid Id { get; set; } = Guid.NewGuid();
        public int ZivotniPoeni { get; set; } = 0;
        public int JacinaNapada { get; set; } = 0;
        public int TrenutnoNovcica { get; set; } = 0;
        public bool JelMrtav {  get; set; } = false;

        public Heroj() { 
        }

        
        public Heroj (string nazivHeroja, int zivotniPoeni, int jacinaNapada, int trenutnoNovcica)
        {
            NazivHeroja = nazivHeroja;
            ZivotniPoeni = zivotniPoeni;
            JacinaNapada = jacinaNapada;
            TrenutnoNovcica = trenutnoNovcica;
            Id = Guid.NewGuid();
            this.JelMrtav = false;
        }
    }
}
