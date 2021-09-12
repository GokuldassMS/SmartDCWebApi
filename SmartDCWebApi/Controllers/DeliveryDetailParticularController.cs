using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartDCWebApi.Models;

namespace SmartDCWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryDetailParticularController : ControllerBase
    {
        private readonly SmartDCContext _context;

        public DeliveryDetailParticularController(SmartDCContext context)
        {
            _context = context;
        }

        // GET: api/DeliveryDetailParticular
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryDetailParticular>>> GetDeliveryDetailParticulars()
        {
            return await _context.DeliveryDetailParticulars.ToListAsync();
        }

        // GET: api/DeliveryDetailParticular/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryDetailParticular>> GetDeliveryDetailParticular(int id)
        {
            var deliveryDetailParticular = await _context.DeliveryDetailParticulars.FindAsync(id);

            if (deliveryDetailParticular == null)
            {
                return NotFound();
            }

            return deliveryDetailParticular;
        }

        // PUT: api/DeliveryDetailParticular/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeliveryDetailParticular(int id, DeliveryDetailParticular deliveryDetailParticular)
        {
            if (id != deliveryDetailParticular.DeliveryDetailParticularId)
            {
                return BadRequest();
            }

            _context.Entry(deliveryDetailParticular).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryDetailParticularExists(id))
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

        // POST: api/DeliveryDetailParticular
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DeliveryDetailParticular>> PostDeliveryDetailParticular(DeliveryDetailParticular deliveryDetailParticular)
        {
            _context.DeliveryDetailParticulars.Add(deliveryDetailParticular);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeliveryDetailParticular", new { id = deliveryDetailParticular.DeliveryDetailParticularId }, deliveryDetailParticular);
        }

        // DELETE: api/DeliveryDetailParticular/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeliveryDetailParticular(int id)
        {
            var deliveryDetailParticular = await _context.DeliveryDetailParticulars.FindAsync(id);
            if (deliveryDetailParticular == null)
            {
                return NotFound();
            }

            _context.DeliveryDetailParticulars.Remove(deliveryDetailParticular);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeliveryDetailParticularExists(int id)
        {
            return _context.DeliveryDetailParticulars.Any(e => e.DeliveryDetailParticularId == id);
        }
    }
}
