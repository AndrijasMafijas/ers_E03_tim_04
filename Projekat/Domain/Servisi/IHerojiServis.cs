using Domain.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servisi
{
    public interface IHerojiServis
    {
        List<Heroj> GetCrveniTimHeroje();
        List<Heroj> GetPlaviTimHeroje();
        public string IspisiListuHeroja();
        public bool PronadjiHeroja(Guid g);
        public Guid PronadjiHeroja(string x);
    }
}
