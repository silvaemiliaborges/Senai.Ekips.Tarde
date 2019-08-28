using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repository
{
    public class FuncionarioRepository
    {
        public List<Funcionario> Listar()
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                // facilitar a nossa vida
                // select * from categorias;
                return ctx.Funcionario.ToList();
            }
        }

        public void Cadastrar (Funcionario funcionario)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                ctx.Funcionario.Add(funcionario);
                ctx.SaveChanges();

            }
        }

        public Funcionario BuscarPorId(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Funcionario.FirstOrDefault(x => x.Idfuncionario == id);
            }
        }

        // atualizar
        public void Atualizar(Funcionario funcionario)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                Funcionario funcionarioBuscado = ctx.Funcionario.FirstOrDefault(x => x.Idfuncionario == funcionario.Idfuncionario);
                // update categorias set nome = @nome
                funcionarioBuscado.Nome = funcionario.Nome;
                // insert - add, delete - remove, update - update
                ctx.Funcionario.Update(funcionarioBuscado);
                // efetivar
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                Funcionario funcionario = ctx.Funcionario.Find(id);
                ctx.Funcionario.Remove(funcionario);
                ctx.SaveChanges();
            }
        }
    }
}
