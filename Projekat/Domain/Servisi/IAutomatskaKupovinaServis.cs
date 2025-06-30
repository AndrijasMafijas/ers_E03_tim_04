using Domain;
using Domain.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servisi
{
     public interface IAutomatskaKupovinaServis
    {
        public string ProveriNovac(Igrac pobednik, int IdProdavnice);


    }
}
