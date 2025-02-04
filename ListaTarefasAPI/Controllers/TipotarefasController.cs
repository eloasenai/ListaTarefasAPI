using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ListaTarefasAPI.Data;
using ListaTarefasAPI.Models;

namespace ListaTarefasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipotarefasController : ControllerBase
    {
        private readonly ListaTarefasContext _context;

        public TipotarefasController(ListaTarefasContext context)
        {
            _context = context;
        }

        // GET: api/Tipotarefas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tipotarefa>>> GetTipotarefas()
        {
            return await _context.Tipotarefas.ToListAsync();
        }

        // GET: api/Tipotarefas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tipotarefa>> GetTipotarefa(int id)
        {
            var tipotarefa = await _context.Tipotarefas.FindAsync(id);

            if (tipotarefa == null)
            {
                return NotFound();
            }

            return tipotarefa;
        }

        // PUT: api/Tipotarefas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipotarefa(int id, Tipotarefa tipotarefa)
        {
            if (id != tipotarefa.id)
            {
                return BadRequest();
            }

            _context.Entry(tipotarefa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipotarefaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tipotarefas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tipotarefa>> PostTipotarefa(Tipotarefa tipotarefa)
        {
            _context.Tipotarefas.Add(tipotarefa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipotarefa", new { id = tipotarefa.id }, tipotarefa);
        }

        // DELETE: api/Tipotarefas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipotarefa(int id)
        {
            var tipotarefa = await _context.Tipotarefas.FindAsync(id);
            if (tipotarefa == null)
            {
                return NotFound();
            }

            _context.Tipotarefas.Remove(tipotarefa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipotarefaExists(int id)
        {
            return _context.Tipotarefas.Any(e => e.id == id);
        }
    }
}
