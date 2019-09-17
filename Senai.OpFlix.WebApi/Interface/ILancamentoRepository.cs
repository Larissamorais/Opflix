using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interface
{
    public interface ILancamentoRepository
    {
        void Cadastrar(Lancamento lancamento);

        List<Lancamento> Listar();

        Lancamento BuscarPorId(int id);

        void Atualizar(Lancamento lancamento);

        void Deletar(int id);


    }
}
