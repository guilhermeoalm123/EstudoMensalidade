﻿using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interface
{
    public interface IServicoKanban
    {
        public Kanban ListarKanban(int codigo);

        

    }
}
