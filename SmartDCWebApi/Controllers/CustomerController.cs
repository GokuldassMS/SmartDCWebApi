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
    public class CustomerController : ControllerBase
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

        public class CustomerParameters
        {
            const int maxPageSize = 50;
            public int PageNumber { get; set; } = 1;
            private int _pageSize = 10;
            public int PageSize
            {
                get
                {
                    return _pageSize;
                }
                set
                {
                    _pageSize = (value > maxPageSize) ? maxPageSize : value;
                }
            }
        }

        public CustomerController(SmartDCContext context)
        {
            _context = context;
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

     
        [HttpGet]
        [Route("GetCustomersByFilter")]
        public IEnumerable<Customer> GetCustomersByFilter([FromQuery] ParamQuery query)
        {
            return this.GetCusts(query);

        }

        [HttpGet]
        [Route("GetCustCount")]
        public int GetCustCount()
        {
            var count = this.FindAll().ToList().Count;
            return count;
        }

        private IEnumerable<Customer> GetCusts(ParamQuery custParameters)
        {
            int pageIndex = Convert.ToInt32(custParameters.pageIndex);
            int pageSize = Convert.ToInt32(custParameters.pageSize);
            var sortField = custParameters.sortField;
            var sortOrder = custParameters.sortOrder;
            string sortFieldOrder = "";
            sortFieldOrder = sortField + "_" + "asc";



            if (sortOrder == "descend")
            {
                sortFieldOrder = sortField + "_" + "desc";
            }

            var cust = this.FindAll()
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize);

            if (custParameters.status != null)
            {
                cust = cust.Where(p => custParameters.status.Contains(p.Status));
            }

            switch (sortFieldOrder)
            {

                case "customerName_desc":
                    cust = cust.OrderByDescending(s => s.CustomerName);
                    break;
                case "gstNo_asc":
                    cust = cust.OrderBy(s => s.GstNo);
                    break;
                case "gstNo_desc":
                    cust = cust.OrderByDescending(s => s.GstNo);
                    break;
                case "city_asc":
                    cust = cust.OrderBy(s => s.City);
                    break;
                case "city_desc":
                    cust = cust.OrderByDescending(s => s.City);
                    break;
                case "phoneNo_asc":
                    cust = cust.OrderBy(s => s.PhoneNo);
                    break;
                case "phoneNo_desc":
                    cust = cust.OrderByDescending(s => s.PhoneNo);
                    break;
                default:
                    cust = cust.OrderBy(s => s.CustomerName);
                    break;
            }
            return cust.ToList();

        }

        private IQueryable<Customer> FindAll()
        {
            return this._context.Set<Customer>();
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        // POST: api/Customer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }

        [HttpPost]
        [Route("GetCustomerNameExists")]
        public async Task<IActionResult> GetCustomerNameExists([FromBody] Customer model)
        {
            IActionResult response = Unauthorized();
            try
            {
                var comp = await (from d in _context.Customers
                                  where d.CustomerName == model.CustomerName
                                  select new Customer
                                  {
                                      CustomerId = d.CustomerId,
                                      CustomerName = d.CustomerName,
                                      GstNo = d.GstNo,
                                      Address1 = d.Address1,
                                      Address2 = d.Address2,
                                      City = d.City,
                                      PinCode = d.PinCode,
                                      PhoneNoCode = d.PhoneNoCode,
                                      PhoneNo = d.PhoneNo,
                                      AltPhoneNoCode = d.AltPhoneNoCode,
                                      AltPhoneNo = d.AltPhoneNo,
                                      Status = d.Status,
                                      CreatedBy = d.CreatedBy,
                                      CreatedOn = d.CreatedOn,
                                      ModifiedBy = d.ModifiedBy,
                                      ModifiedOn = d.ModifiedOn
                                  }).FirstOrDefaultAsync();

                if (comp == null)
                {
                    response = Ok(new
                    {
                        Status = "NotExist",
                        Message = ""
                    });
                    return response;
                }
                else
                {
                    response = Ok(new
                    {
                        Status = "Exist",
                        Message = "Customer name is already exists. Please try another one."
                    });
                    return response;
                }

                return Ok(comp);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
