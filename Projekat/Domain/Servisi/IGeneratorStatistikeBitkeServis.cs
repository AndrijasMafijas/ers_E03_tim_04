﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servisi
{
    public interface IGeneratorStatistikeBitkeServis
    {
        string IspisiStatistikuBitke(int idProdavnice, string nazivMape);
    }
}
