﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periferia.Models.EntityModels
{
    public class Producto : EntityBase
    {
        public string Nombre { get; set; }
        public double ValorUnitario { get; set; }
    }
}
