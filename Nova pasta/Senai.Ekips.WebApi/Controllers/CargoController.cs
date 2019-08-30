using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.Repository;

namespace Senai.Ekips.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        CargoRepository CargoRepository = new CargoRepository();
        //[Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(CargoRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Cargo cargo)
        {
            try
            {
                CargoRepository.Cadastrar(cargo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "meu amigo mehhh deu erroh " + ex.Message });
            }
        }

        //[Authorize(Roles = "ADMIN")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Cargo cargo = CargoRepository.BuscarPorId(id);
            if (cargo == null)
                return NotFound();
            return Ok(cargo);
        }

        [HttpPut]
        public IActionResult Atualizar(Cargo cargo)
        {
            try
            {
                // pesquisar uma categoria
                Cargo CargoBuscado = CargoRepository.BuscarPorId(cargo.Idcargo);
                // caso nao encontre, not found
                if (CargoBuscado == null)
                    return NotFound();
                // caso contrario, se ela for encontrada, eu atualizo pq quero
                CargoRepository.Atualizar(cargo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "a." });
            }
        }
    }
}