using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(departamentoRepository.Listar());

        }
    }
}
