using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interface
{
    public interface ICategoriaRepository
    {
        void Cadastrar(Categoria categoria);

        List<Categoria> Listar();

      
        Categoria BuscarPorId(int id);
    }
}
