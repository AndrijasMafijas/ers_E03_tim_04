﻿using Domain.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servisi
{
    public interface IProdavnica
    {
        public bool DodajOruzje(Oruzje x);
        public bool DodajNapitak(Napitak x);
    }
}
