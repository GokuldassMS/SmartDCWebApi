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

        public class ParamQuery
        {
            public int? pageIndex { get; set; }
            public int? pageSize { get; set; }
            public string sortField { get; set; }
            public string sortOrder { get; set; }
            public string[] status { get; set; }

        }

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

        [HttpGet]
        [Route("GetDeliveryDetailsByFilter")]
        public IEnumerable<DeliveryDetails> GetDeliveryDetailsByFilter([FromQuery] ParamQuery query)
        {
            return this.GetDeliveryDetails(query);

        }

        [HttpGet]
        [Route("GetDeliveryDetailsCount")]
        public int GetDeliveryDetailsCount()
        {
            var count = this.FindAll().ToList().Count;
            return count;
        }

        private IEnumerable<DeliveryDetails> GetDeliveryDetails(ParamQuery purchaseDetailsParameters)
        {
            int pageIndex = Convert.ToInt32(purchaseDetailsParameters.pageIndex);
            int pageSize = Convert.ToInt32(purchaseDetailsParameters.pageSize);
            var sortField = purchaseDetailsParameters.sortField;
            var sortOrder = purchaseDetailsParameters.sortOrder;
            string sortFieldOrder = "";
            sortFieldOrder = sortField + "_" + "asc";

            if (sortOrder == "descend")
            {
                sortFieldOrder = sortField + "_" + "desc";
            }

            var cust = this.FindAll()
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize);

            switch (sortFieldOrder)
            {

                case "customerName_desc":
                    cust = cust.OrderByDescending(s => s.CustomerName);
                    break;
                case "deliveryDate_asc":
                    cust = cust.OrderBy(s => s.DeliveryDate);
                    break;
                case "deliveryDate_desc":
                    cust = cust.OrderByDescending(s => s.DeliveryDate);
                    break;
                case "challanNo_asc":
                    cust = cust.OrderBy(s => s.ChallanNo);
                    break;
                case "challanNo_desc":
                    cust = cust.OrderByDescending(s => s.ChallanNo);
                    break;
                case "partyDcNo_asc":
                    cust = cust.OrderBy(s => s.PartyDcNo);
                    break;
                case "partyDcNo_desc":
                    cust = cust.OrderByDescending(s => s.PartyDcNo);
                    break;
                case "vehicleNo_asc":
                    cust = cust.OrderBy(s => s.VehicleNo);
                    break;
                case "vehicleNo_desc":
                    cust = cust.OrderByDescending(s => s.VehicleNo);
                    break;
                default:
                    cust = cust.OrderBy(s => s.CustomerName);
                    break;
            }
            return cust.ToList();

        }

        private IEnumerable<DeliveryDetails> FindAll()
        {
            //return this._context.Set<PurchaseDetail>();

            return (from d in _context.DeliveryDetails
                    from dp in _context.DeliveryDetailParticulars
                    from p in _context.PurchaseDetails
                    from c in _context.Customers
                    where dp.DeliveryId == d.DeliveryId
                    && d.PurchaseId == p.PurchaseId
                    && c.CustomerId == p.CustomerId
                    select new DeliveryDetails
                    {
                        DeliveryId = d.DeliveryId,
                        PurchaseId = p.PurchaseId,
                        CustomerName = c.CustomerName,
                        CustomerId = p.CustomerId,
                        DeliveryDate = d.DeliveryDate,
                        ChallanNo = d.ChallanNo,
                        PartyDcNo = d.PartyDcNo,
                        VehicleNo = d.VehicleNo,
                        Status = dp.Status,
                        CompanyId = p.CompanyId,
                        CreatedBy = p.CreatedBy,
                        CreatedOn = p.CreatedOn,
                        ModifiedBy = p.ModifiedBy,
                        ModifiedOn = p.ModifiedOn

                    }).ToList();
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
