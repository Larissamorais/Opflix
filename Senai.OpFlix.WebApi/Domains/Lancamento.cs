using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Lancamento
    {
        public int? IdCategoria { get; set; }
        public int? IdPermissao { get; set; }
        public string Titulo { get; set; }
        public string Sinopse { get; set; }
        public string Tipo { get; set; }
        public string Tempo { get; set; }
        public string DataDeLancamento { get; set; }
        public int IdLancamento { get; set; }

        public Categoria IdCategoriaNavigation { get; set; }
        public Permissao IdPermissaoNavigation { get; set; }
    }
}
