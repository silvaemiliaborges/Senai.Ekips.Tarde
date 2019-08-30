using Microsoft.EntityFrameworkCore;
using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repository
{
    public class DepartamentoRepository
    {
        public List<Departamento> Listar()
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                // facilitar a nossa vida
                // select * from categorias;
                return ctx.Departamento.ToList();
            }
        }

        public void Cadastrar(Departamento departamento)
            {
                using (EkipsContext ctx = new EkipsContext())
                {
                    ctx.Departamento.Add(departamento);
                    ctx.SaveChanges();

            }
        }

        public Departamento BuscarPorId(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Departamento.FirstOrDefault(X => X.Iddepartamento == id);

            }
        }
    }
}
