using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        public void Cadastrar(Categoria categoria)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Categoria.Add(categoria);
                ctx.SaveChanges();
            }
        }
    }
}
