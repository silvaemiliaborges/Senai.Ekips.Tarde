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

       
    }
}
