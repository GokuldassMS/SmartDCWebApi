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
    public class CompanyController : ControllerBase
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

        public class CompanyParameters
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

        public CompanyController(SmartDCContext context)
        {
            _context = context;
        }

        // GET: api/Company
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
        {
            return await _context.Companies.ToListAsync();
        }


        // GET: api/Company
        [HttpGet]
        [Route("GetCompaniesByFilter")]
        public IEnumerable<Company> GetCompaniesByFilter([FromQuery] ParamQuery query)
        {
            //return await _context.Departments.ToListAsync();
            return this.GetComps(query);

        }

        [HttpGet]
        [Route("GetCompCount")]
        public int GetCompCount()
        {
            var count = this.FindAll().ToList().Count;
            return count;
        }

        private IEnumerable<Company> GetComps(ParamQuery compParameters)
        {
            int pageIndex = Convert.ToInt32(compParameters.pageIndex);
            int pageSize = Convert.ToInt32(compParameters.pageSize);
            var sortField = compParameters.sortField;
            var sortOrder = compParameters.sortOrder;
            string sortFieldOrder = "";
            sortFieldOrder = sortField + "_" + "asc";



            if (sortOrder == "descend")
            {
                sortFieldOrder = sortField + "_" + "desc";
            }

            var comp = this.FindAll()
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize);

            if (compParameters.status != null)
            {
                comp = comp.Where(p => compParameters.status.Contains(p.Status));
            }

            switch (sortFieldOrder)
            {

                case "companyName_desc":
                    comp = comp.OrderByDescending(s => s.CompanyName);
                    break;
                case "gstNo_asc":
                    comp = comp.OrderBy(s => s.GstNo);
                    break;
                case "gstNo_desc":
                    comp = comp.OrderByDescending(s => s.GstNo);
                    break;
                case "city_asc":
                    comp = comp.OrderBy(s => s.City);
                    break;
                case "city_desc":
                    comp = comp.OrderByDescending(s => s.City);
                    break;
                case "phoneNo_asc":
                    comp = comp.OrderBy(s => s.PhoneNo);
                    break;
                case "phoneNo_desc":
                    comp = comp.OrderByDescending(s => s.PhoneNo);
                    break;
                default:
                    comp = comp.OrderBy(s => s.CompanyName);
                    break;
            }
            return comp.ToList();

        }

        private IQueryable<Company> FindAll()
        {
            return this._context.Set<Company>();
        }

        // GET: api/Company/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            var company = await _context.Companies.FindAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            return company;
        }

        // PUT: api/Company/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(int id, Company company)
        {
            if (id != company.CompanyId)
            {
                return BadRequest();
            }

            _context.Entry(company).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(id))
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

        // POST: api/Company
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Company>> PostCompany(Company company)
        {
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompany", new { id = company.CompanyId }, company);
        }

        // DELETE: api/Company/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompanyExists(int id)
        {
            return _context.Companies.Any(e => e.CompanyId == id);
        }


        [HttpPost]
        [Route("GetCompanyNameExists")]
        public async Task<IActionResult> GetCompanyNameExists([FromBody] Company model)
        {
            IActionResult response = Unauthorized();
            try
            {
                var comp = await (from d in _context.Companies
                                  where d.CompanyName == model.CompanyName
                                  select new Company
                                  {
                                        CompanyId = d.CompanyId,
                                        CompanyName = d.CompanyName,
                                        GstNo = d.GstNo,
                                        Address1 =d.Address1,
                                        Address2 =d.Address2,
                                        City =d.City,
                                        PinCode =d.PinCode,
                                        PhoneNoCode =d.PhoneNoCode,
                                        PhoneNo =d.PhoneNo,
                                        AltPhoneNoCode =d.AltPhoneNoCode,
                                        AltPhoneNo =d.AltPhoneNo,
                                        Status =d.Status,
                                        CreatedBy =d.CreatedBy,
                                        CreatedOn =d.CreatedOn,
                                        ModifiedBy =d.ModifiedBy,
                                        ModifiedOn =d.ModifiedOn
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
                        Message = "Company name is already exists. Please try another one."
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
