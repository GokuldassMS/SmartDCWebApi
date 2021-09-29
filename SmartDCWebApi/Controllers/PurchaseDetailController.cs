using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartDCWebApi.Models;
using System.Globalization;

namespace SmartDCWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseDetailController : ControllerBase
    {
        private readonly SmartDCContext _context;

        public class ParamQuery
        {
            public int? pageIndex { get; set; }
            public int? pageSize { get; set; }
            public string sortField { get; set; }
            public string sortOrder { get; set; }
            public string[] status { get; set; }
            public string dcNo { get; set; }
            public int? companyId { get; set; }
            public int? customerId { get; set; }
            public string purchaseDate { get; set; }

        }

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

        [HttpGet]
        [Route("GetPurchaseDetailsByFilter")]
        public IEnumerable<PurchaseDetails> GetPurchaseDetailsByFilter([FromQuery] ParamQuery query)
        {
            return this.GetPurchaseDetails(query);

        }

        [HttpGet]
        [Route("GetPurchaseDetailsCount")]
        public int GetPurchaseDetailsCount()
        {
            var count = this.FindAll().ToList().Count;
            return count;
        }

        private IEnumerable<PurchaseDetails> GetPurchaseDetails(ParamQuery purchaseDetailsParameters)
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
                case "purchaseDate_asc":
                    cust = cust.OrderBy(s => s.PurchaseDate);
                    break;
                case "purchaseDate_desc":
                    cust = cust.OrderByDescending(s => s.PurchaseDate);
                    break;
                case "dcNo_asc":
                    cust = cust.OrderBy(s => s.DcNo);
                    break;
                case "dcNo_desc":
                    cust = cust.OrderByDescending(s => s.DcNo);
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

        private IEnumerable<PurchaseDetails> FindAll()
        {
           
            return (from p in _context.PurchaseDetails
                    from c in _context.Customers
                    where c.CustomerId == p.CustomerId
                    select new PurchaseDetails
                    {
                        PurchaseId = p.PurchaseId,
                        CustomerName = c.CustomerName,
                        CustomerId = p.CustomerId,
                        PurchaseDate = p.PurchaseDate,
                        DcNo = p.DcNo,
                        VehicleNo = p.VehicleNo,
                        StyleNo = p.StyleNo,
                        CompanyId = p.CompanyId,
                        CreatedBy = p.CreatedBy,
                        CreatedOn = p.CreatedOn,
                        ModifiedBy = p.ModifiedBy,
                        ModifiedOn = p.ModifiedOn,
                        PurchaseDetailParticulars = _context.PurchaseDetailParticulars.Where(e => e.PurchaseId == p.PurchaseId).ToList()
                    }).ToList();

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

        [HttpGet]
        [Route("GetPurchaseDetailsBySearch")]
        public IEnumerable<PurchaseDetails> GetPurchaseDetailsBySearch([FromQuery] ParamQuery query)
        {
            //return this.GetPurchaseDetails(query);

            int pageIndex = Convert.ToInt32(query.pageIndex);
            int pageSize = Convert.ToInt32(query.pageSize);
            int companyId = Convert.ToInt32(query.companyId);
            int customerId = Convert.ToInt32(query.customerId);
            //string purchaseDate = Convert.ToString(query.purchaseDate);
            string dcNo = Convert.ToString(query.dcNo);
            DateTime purchaseDate = Convert.ToDateTime(query.purchaseDate);
            //DateTime purchaseDate = DateTime.ParseExact(query.purchaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            var cust = this.FindAll()
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize);

            if (companyId != 0)
            {
                cust = cust.Where(p => query.companyId == p.CompanyId);
            }
            if (customerId != 0)
            {
                cust = cust.Where(p => query.customerId == p.CustomerId);
            }
            if (dcNo != null && dcNo != "null" && dcNo != "undefined")
            {
                cust = cust.Where(p => p.DcNo.ToUpper().Contains(dcNo.ToUpper()));
            }
            if (purchaseDate !=null)
            {
                cust = cust.Where(p => DateTime.Compare(p.PurchaseDate, purchaseDate) >= 0);
            }

            cust = cust.OrderBy(s => s.CustomerName);
            return cust.ToList();

        }

    }
}
