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
    public class PurchaseDetailController : ControllerBase
    {
        private readonly SmartDCContext _context;

        public PurchaseDetailController(SmartDCContext context)
        {
            _context = context;
        }

        // GET: api/PurchaseDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseDetail>>> GetPurchaseDetails()
        {
            return await _context.PurchaseDetails.ToListAsync();
        }

        // GET: api/PurchaseDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseDetail>> GetPurchaseDetail(int id)
        {
            var purchaseDetail = await _context.PurchaseDetails.FindAsync(id);

            if (purchaseDetail == null)
            {
                return NotFound();
            }

            return purchaseDetail;
        }

        // PUT: api/PurchaseDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchaseDetail(int id, PurchaseDetail purchaseDetail)
        {
            if (id != purchaseDetail.PurchaseId)
            {
                return BadRequest();
            }

            _context.Entry(purchaseDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseDetailExists(id))
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

        // POST: api/PurchaseDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PurchaseDetail>> PostPurchaseDetail(PurchaseDetail purchaseDetail)
        {
            _context.PurchaseDetails.Add(purchaseDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPurchaseDetail", new { id = purchaseDetail.PurchaseId }, purchaseDetail);
        }

        // DELETE: api/PurchaseDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchaseDetail(int id)
        {
            var purchaseDetail = await _context.PurchaseDetails.FindAsync(id);
            if (purchaseDetail == null)
            {
                return NotFound();
            }

            _context.PurchaseDetails.Remove(purchaseDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PurchaseDetailExists(int id)
        {
            return _context.PurchaseDetails.Any(e => e.PurchaseId == id);
        }
    }
}
