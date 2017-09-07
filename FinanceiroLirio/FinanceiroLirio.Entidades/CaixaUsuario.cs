﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceiroLirio.Entidades
{
    public class CaixaUsuario
    {
        public int IdUsuarioCaixa { get; set; }
        public int IdUsuario { get; set; }
        public int IdCaixa { get; set; }
        public DateTime DataInclusao { get; set; }
        public int IdOperadorInclusao { get; set; }
    }
}
