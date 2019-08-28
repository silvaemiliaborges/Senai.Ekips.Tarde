using System;
using System.Collections.Generic;

namespace Senai.Ekips.WebApi.Domains
{
    public partial class Permissao
    {
        public Permissao()
        {
            Usuariovinculado = new HashSet<Usuariovinculado>();
        }

        public int Idpermissao { get; set; }
        public string Permissao1 { get; set; }

        public ICollection<Usuariovinculado> Usuariovinculado { get; set; }
    }
}
