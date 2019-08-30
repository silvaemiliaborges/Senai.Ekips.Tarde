using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repository
{
    public class CargoRepository
    {
        public List<Cargo> Listar()
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                // facilitar a nossa vida
                // select * from categorias;
                return ctx.Cargo.ToList();
            }
        }

        public void Cadastrar(Cargo cargo)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                // insert into categorias (nome) values (@nome);
                ctx.Cargo.Add(cargo);
                ctx.SaveChanges();
            }
        }

        //buscar por id
        public Cargo BuscarPorId(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Cargo.FirstOrDefault(x => x.Idcargo == id);
            }
        }

        // atualizar
        public void Atualizar(Cargo cargo)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                Cargo CargoBuscado = ctx.Cargo.FirstOrDefault(x => x.Idcargo == cargo.Idcargo);
                // update categorias set nome = @nome
                CargoBuscado.Cargo1 = cargo.Cargo1;
                // insert - add, delete - remove, update - update
                ctx.Cargo.Update(CargoBuscado);
                // efetivar
                ctx.SaveChanges();
            }
        }


    }
}
