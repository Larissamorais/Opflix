using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int? IdP { get; set; }
        public string Imagem { get; set; }

        public Permissao IdPNavigation { get; set; }
    }
}
