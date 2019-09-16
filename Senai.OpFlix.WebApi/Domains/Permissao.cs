using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Permissao
    {
        public Permissao()
        {
            Lancamento = new HashSet<Lancamento>();
            Usuario = new HashSet<Usuario>();
        }

        public int IdPermissao { get; set; }
        public string Nome { get; set; }

        public ICollection<Lancamento> Lancamento { get; set; }
        public ICollection<Usuario> Usuario { get; set; }
    }
}
