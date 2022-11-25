using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservaPedidos.ClientAPI;
using ReservaPedidos.Data;

namespace ReservaPedidos.ClientAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ReservaPedidosContext _context;

        public ClientsController(ReservaPedidosContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClient()
        {
            return await _context.Client.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(long id)
        {
            var client = await _context.Client.FindAsync(id);

            if (client == null)
				return NotFound();

			return client;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(long id, Client client)
        {
            if (id != client.Id)
				return BadRequest();

			_context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
					return NotFound();
				else
					throw;
			}

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(Client client)
        {
            _context.Client.Add(client);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClient", new { id = client.Id }, client);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(long id)
        {
            var client = await _context.Client.FindAsync(id);

            if (client == null)
               return NotFound();

			_context.Client.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientExists(long id)
        {
            return _context.Client.Any(e => e.Id == id);
        }
    }
}
