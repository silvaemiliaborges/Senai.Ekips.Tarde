using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.Repository;

namespace Senai.Ekips.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        FuncionarioRepository funcionarioRepository = new FuncionarioRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(funcionarioRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar (Funcionario funcionario)
        {
            try
            {
                funcionarioRepository.Cadastrar(funcionario);
                return Ok();

            }
            catch(Exception ex)
            {
                return BadRequest(new { message = "Mehhhhhhhhhh!!!!!!!!!!!!!!!!!!!!!!! " + ex.Message });
            }
        }


        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Funcionario funcionario = funcionarioRepository.BuscarPorId(id);
            if (funcionario == null)
                return NotFound();
            return Ok(funcionario);
        }

        [HttpPut]
        public IActionResult Atualizar(Funcionario funcionario)
        {
            try
            {
                // pesquisar uma categoria
                Funcionario funcionarioBuscado = funcionarioRepository.BuscarPorId(funcionario.Idfuncionario);
                // caso nao encontre, not found
                if (funcionarioBuscado == null)
                    return NotFound();
                // caso contrario, se ela for encontrada, eu atualizo pq queroreturn NotFound();
                funcionarioRepository.Atualizar(funcionario);
                return Ok();


            }
            catch(Exception ex)
            {
                return BadRequest(new { mensagem = "meh" });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            funcionarioRepository.Deletar(id);
            return Ok();
        }
    }
}