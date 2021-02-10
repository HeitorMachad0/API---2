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
    [Route("V1/Contrato")]
    public class ContratoController: ControllerBase
    {
        [HttpGet]
        [Route("")]

        public async Task<ActionResult<List<Contrato>>> Get([FromServices] DataContext context)
        {
            var contratos = await context.Contratos.ToListAsync();
            return contratos;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Contrato>> GetById([FromServices] DataContext context, int id)
        {
            var contratos = await context.Contratos.Include(x => x.Prestacoes).FirstOrDefaultAsync(x => x.ID == id);
            return contratos;
        }

        [HttpPost]
        [Route("")]

        public async Task<ActionResult<Contrato>> Post([FromServices] DataContext context, [FromBody] Contrato model)
        {
            if (ModelState.IsValid)
            {
                context.Contratos.Add(model);
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
