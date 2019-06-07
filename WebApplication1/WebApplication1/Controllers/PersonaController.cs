using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApplication1.Contexts;
using WebApplication1.Entities;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")] // Toma el control defindo
    [ApiController]
    public class PersonaController: ControllerBase
    {
        public DbContext_SMR Context_SMR { get; }
    
        public PersonaController(DbContext_SMR varContext)
        {
            Context_SMR = varContext;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<Persona>> Get()
        {
            return Context_SMR.TablaPersona.ToList();
        }
        
        [HttpGet("{id}", Name = "ObtenerPersona")]
        public ActionResult<Persona> Get(int id)
        {
            var varPersona = Context_SMR.TablaPersona.FirstOrDefault(x => x.Id == id);

            if (varPersona == null)
            {
                return NotFound();
            }

            return varPersona;

        }
        
        [HttpPost]
        public ActionResult Post([FromBody] Persona varPersona)
        {
            //ModelState no es necesario de netcore 2.1, por ejemplo si en la clase autor uso un [Required]
            //if(!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            Context_SMR.TablaPersona.Add(varPersona);
            Context_SMR.SaveChanges();
            return new CreatedAtRouteResult("ObtenerPersona", new { id = varPersona.Id }, varPersona);

        }
        
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Persona xPersona)
        {
            Context_SMR.Entry(xPersona).State = EntityState.Modified;
            Context_SMR.SaveChanges();
            return Ok();
        }
        
        // DELETE api/autores/5
        [HttpDelete("{id}")]
        public ActionResult<Persona> Delete(int id)
        {
            var ElimPersona = Context_SMR.TablaPersona.FirstOrDefault(x => x.Id == id);

            if (ElimPersona == null)
            {
                return NotFound();
            }

            Context_SMR.Remove(ElimPersona);
            Context_SMR.SaveChanges();
            return Ok(ElimPersona);
        }

    }
}
