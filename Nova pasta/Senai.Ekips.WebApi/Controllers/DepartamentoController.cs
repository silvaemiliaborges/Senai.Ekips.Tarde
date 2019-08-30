using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]

    public class DepartamentoController : ControllerBase
    {
        DepartamentoRepository departamentoRepository = new DepartamentoRepository();
        //[Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(departamentoRepository.Listar());

        }
        //só quem é "admin" pode buscar por id bjsss negahhh 
        //[Authorize(Roles = "ADMIN")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Departamento departamento = departamentoRepository.BuscarPorId(id);
            if (departamento == null)
                return NotFound();
            return Ok(departamento);
        }
        [HttpPost]
        public IActionResult Cadastrar(Departamento departamento)
        {
            try
            {
                departamentoRepository.Cadastrar(departamento);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Pohhh" + ex.Message });
            }
        }

    }
}
