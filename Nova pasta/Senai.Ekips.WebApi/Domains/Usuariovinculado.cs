using System;
using System.Collections.Generic;

namespace Senai.Ekips.WebApi.Domains
{
    public partial class Usuariovinculado
    {
        public Usuariovinculado()
        {
            Funcionario = new HashSet<Funcionario>();
        }

        public int Idusuariovinculado { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int? Idpermissao { get; set; }

        public Permissao IdpermissaoNavigation { get; set; }
        public ICollection<Funcionario> Funcionario { get; set; }
    }
}
