using Microsoft.EntityFrameworkCore;
using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repository
{
    public class UsuariovinculadoRepository
    {
        public Usuariovinculado BuscarPorEmailESenha(UsuarioViewModel login)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                //PERMISSÃO -idpermissaõ
                Usuariovinculado usuario = ctx.Usuariovinculado.Include(x => x.IdpermissaoNavigation).FirstOrDefault(
                    x => x.Email == login.Email && x.Senha == login.Senha);
                if (usuario == null)
                    return null;
                return usuario;
            }

        }
        public List<Usuariovinculado> Listar()
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Usuariovinculado.ToList();
                
            }
        }
    }

}
