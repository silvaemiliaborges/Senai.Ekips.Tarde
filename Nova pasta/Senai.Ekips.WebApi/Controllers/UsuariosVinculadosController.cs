using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.Repository;
using Senai.Ekips.WebApi.ViewModel;

namespace Senai.Ekips.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosVinculadosController : ControllerBase
    {

        UsuariovinculadoRepository usuariosVinculadosRepository = new UsuariovinculadoRepository();

        [HttpGet]

        public IActionResult Listar()
        {
            return Ok(usuariosVinculadosRepository.Listar());
        }

        [HttpPost]
        public IActionResult Login(UsuarioViewModel login)
        {
            try
            {
                Usuariovinculado usuariovinculadoBuscado = usuariosVinculadosRepository.BuscarPorEmailESenha(login);
                if (usuariovinculadoBuscado == null)
                    return NotFound(new { mensagem = "Môhhhh senha incorretahh!" });

                var claims = new[]
     {
                    // chave customizada
                    new Claim("emilha", "1234"),
                    new Claim("mare", "bla"),
                    // email
                    new Claim(JwtRegisteredClaimNames.Email, usuariovinculadoBuscado.Email),
                    // id
                    new Claim(JwtRegisteredClaimNames.Jti, usuariovinculadoBuscado.Idusuariovinculado.ToString()),
                    // permissao
                    new Claim(ClaimTypes.Role, usuariovinculadoBuscado.IdpermissaoNavigation.Permissao1),
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("gufos-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "Ekips.WebApi",
                    audience: "Ekips.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao cadastrar." + ex.Message });
            }
        }

    }
}