using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("V1/Prestacoes")]
    public class PrestacaoController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Prestacao>>> Get([FromServices] DataContext context)
        {
            var prestacoes = await context.Prestacoes.Include(x => x.Contrato).ToListAsync();
            return prestacoes;
        }

        [HttpPost]
        [Route("")]

        public async Task<ActionResult<Prestacao>> Post([FromServices] DataContext context, [FromBody] Prestacao model)
        {
            if (ModelState.IsValid)
            {
                context.Prestacoes.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
