using System;
using System.Collections.Generic;

namespace Senai.Ekips.WebApi.Domains
{
    public partial class Funcionario
    {
        public int Idfuncionario { get; set; }
        public string Nome { get; set; }
        public int Cpf { get; set; }
        public DateTime? Datanascimento { get; set; }
        public int Salario { get; set; }
        public int? Iddepartamento { get; set; }
        public int? Idcargo { get; set; }
        public int? Idusuariovinculado { get; set; }

        public Cargo IdcargoNavigation { get; set; }
        public Departamento IddepartamentoNavigation { get; set; }
        public Usuariovinculado IdusuariovinculadoNavigation { get; set; }
    }
}
