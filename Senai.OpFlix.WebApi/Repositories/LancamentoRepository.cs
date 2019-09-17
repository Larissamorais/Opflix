using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class LancamentoRepository : ILancamentoRepository
    {
        public void Atualizar(Lancamento lancamento)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Lancamento LancamentoBuscada = ctx.Lancamento.FirstOrDefault(x => x.IdLancamento == lancamento.IdLancamento);

                LancamentoBuscada.Nome = lancamento.Nome;

                ctx.Lancamento.Update(LancamentoBuscada);

                ctx.SaveChanges();
            }
        }

        public Lancamento BuscarPorId(int id)
        {
            using( OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Lancamento.Find(id);
            }
        }

        public void Cadastrar(Lancamento lancamento)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Lancamento.Add(lancamento);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
               
                Lancamento Categoria = ctx.Lancamento.Find(id);

                ctx.Lancamento.Remove(Categoria);

                ctx.SaveChanges();
            }
        }

        public List<Lancamento> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Lancamento.ToList();
            }
        }

    }
}
