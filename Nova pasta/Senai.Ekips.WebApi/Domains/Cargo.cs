using System;
using System.Collections.Generic;

namespace Senai.Ekips.WebApi.Domains
{
    public partial class Cargo
    {
        public Cargo()
        {
            Funcionario = new HashSet<Funcionario>();
        }

        public int Idcargo { get; set; }
        public string Cargo1 { get; set; }

        public ICollection<Funcionario> Funcionario { get; set; }
    }
}
