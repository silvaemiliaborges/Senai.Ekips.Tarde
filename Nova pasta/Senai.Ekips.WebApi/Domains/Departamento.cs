using System;
using System.Collections.Generic;

namespace Senai.Ekips.WebApi.Domains
{
    public partial class Departamento
    {
        public Departamento()
        {
            Funcionario = new HashSet<Funcionario>();
        }

        public int Iddepartamento { get; set; }
        public string Departamento1 { get; set; }
        

        public ICollection<Funcionario> Funcionario { get; set; }

        //public Funcionario IdFunconarioNavigation { get; set; }
    }
}
