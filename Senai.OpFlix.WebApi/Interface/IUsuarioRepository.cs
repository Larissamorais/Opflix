﻿using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interface
{
    interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);
    }
}
