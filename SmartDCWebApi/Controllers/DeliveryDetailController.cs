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
    public class DeliveryDetailController : ControllerBase
    {
        private readonly SmartDCContext _context;

        public DeliveryDetailController(SmartDCContext context)
        {
            _context = context;
        }

        // GET: api/DeliveryDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryDetail>>> GetDeliveryDetails()
        {
            return await _context.DeliveryDetails.ToListAsync();
        }

        // GET: api/DeliveryDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryDetail>> GetDeliveryDetail(int id)
        {
            var deliveryDetail = await _context.DeliveryDetails.FindAsync(id);

            if (deliveryDetail == null)
            {
                return NotFound();
            }

            return deliveryDetail;
        }

        // PUT: api/DeliveryDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeliveryDetail(int id, DeliveryDetail deliveryDetail)
        {
            if (id != deliveryDetail.DeliveryId)
            {
                return BadRequest();
            }

            _context.Entry(deliveryDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryDetailExists(id))
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

        // POST: api/DeliveryDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DeliveryDetail>> PostDeliveryDetail(DeliveryDetail deliveryDetail)
        {
            _context.DeliveryDetails.Add(deliveryDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeliveryDetail", new { id = deliveryDetail.DeliveryId }, deliveryDetail);
        }

        // DELETE: api/DeliveryDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeliveryDetail(int id)
        {
            var deliveryDetail = await _context.DeliveryDetails.FindAsync(id);
            if (deliveryDetail == null)
            {
                return NotFound();
            }

            _context.DeliveryDetails.Remove(deliveryDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeliveryDetailExists(int id)
        {
            return _context.DeliveryDetails.Any(e => e.DeliveryId == id);
        }
    }
}
