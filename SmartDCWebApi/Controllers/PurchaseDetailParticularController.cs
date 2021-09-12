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
    public class PurchaseDetailParticularController : ControllerBase
    {
        private readonly SmartDCContext _context;

        public PurchaseDetailParticularController(SmartDCContext context)
        {
            _context = context;
        }

        // GET: api/PurchaseDetailParticular
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseDetailParticular>>> GetPurchaseDetailParticulars()
        {
            return await _context.PurchaseDetailParticulars.ToListAsync();
        }

        // GET: api/PurchaseDetailParticular/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseDetailParticular>> GetPurchaseDetailParticular(int id)
        {
            var purchaseDetailParticular = await _context.PurchaseDetailParticulars.FindAsync(id);

            if (purchaseDetailParticular == null)
            {
                return NotFound();
            }

            return purchaseDetailParticular;
        }

        // PUT: api/PurchaseDetailParticular/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchaseDetailParticular(int id, PurchaseDetailParticular purchaseDetailParticular)
        {
            if (id != purchaseDetailParticular.PurchaseDetailParticularId)
            {
                return BadRequest();
            }

            _context.Entry(purchaseDetailParticular).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseDetailParticularExists(id))
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

        // POST: api/PurchaseDetailParticular
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PurchaseDetailParticular>> PostPurchaseDetailParticular(PurchaseDetailParticular purchaseDetailParticular)
        {
            _context.PurchaseDetailParticulars.Add(purchaseDetailParticular);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPurchaseDetailParticular", new { id = purchaseDetailParticular.PurchaseDetailParticularId }, purchaseDetailParticular);
        }

        // DELETE: api/PurchaseDetailParticular/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchaseDetailParticular(int id)
        {
            var purchaseDetailParticular = await _context.PurchaseDetailParticulars.FindAsync(id);
            if (purchaseDetailParticular == null)
            {
                return NotFound();
            }

            _context.PurchaseDetailParticulars.Remove(purchaseDetailParticular);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PurchaseDetailParticularExists(int id)
        {
            return _context.PurchaseDetailParticulars.Any(e => e.PurchaseDetailParticularId == id);
        }
    }
}
