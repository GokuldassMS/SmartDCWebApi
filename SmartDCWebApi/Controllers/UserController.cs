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
    public class UserController : ControllerBase
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

        public class UserParameters
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

        public UserController(SmartDCContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }

        private bool UserNameExists(string username)
        {
            return _context.Users.Any(e => e.UserName == username);
        }

        [HttpPost]
        [Route("GetUserNameExists")]
        public async Task<IActionResult> GetUserNameExists([FromBody] User model)
        {
            IActionResult response = Unauthorized();
            try
            {
                var user = await (from u in _context.Users
                                  where u.UserName == model.UserName
                                  select new User
                                  {
                                      UserId = u.UserId,
                                      FirstName = u.FirstName,
                                      LastName = u.LastName,
                                      UserName = u.UserName,
                                      Password = u.Password,
                                      Status = u.Status,
                                      PhoneNoCode = u.PhoneNoCode,
                                      PhoneNo = u.PhoneNoCode,
                                      Email = u.Email
                                  }).FirstOrDefaultAsync();

                if (user == null)
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
                        Message = "Username is already exists. Please try another one."
                    });
                    return response;
                }

                return Ok(user);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetUserCount")]
        public int GetUserCount()
        {
            var count = this.FindAll().ToList().Count;
            return count;
        }

        private IQueryable<User> FindAll()
        {
            return this._context.Set<User>();
        }

        // GET: api/User
        [HttpGet]
        [Route("GetUsersByFilter")]
        public IEnumerable<User> GetUsersByFilter([FromQuery] ParamQuery query)
        {
            return this.GetUsers(query);
        }

        private IEnumerable<User> GetUsers(ParamQuery userParameters)
        {
            int pageIndex = Convert.ToInt32(userParameters.pageIndex);
            int pageSize = Convert.ToInt32(userParameters.pageSize);
            var sortField = userParameters.sortField;
            var sortOrder = userParameters.sortOrder;
            string sortFieldOrder = "";
            sortFieldOrder = sortField + "_" + "asc";



            if (sortOrder == "descend")
            {
                sortFieldOrder = sortField + "_" + "desc";
            }

            var user = this.FindAll()
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize);

            if (userParameters.status != null)
            {
                user = user.Where(p => userParameters.status.Contains(p.Status));
            }

            switch (sortFieldOrder)
            {

                case "firstName_desc":
                    user = user.OrderByDescending(s => s.FirstName);
                    break;
                case "lastName_asc":
                    user = user.OrderBy(s => s.LastName);
                    break;
                case "lastName_desc":
                    user = user.OrderByDescending(s => s.LastName);
                    break;
                case "userName_asc":
                    user = user.OrderBy(s => s.LastName);
                    break;
                case "userName_desc":
                    user = user.OrderByDescending(s => s.UserName);
                    break;
                default:
                    user = user.OrderBy(s => s.FirstName);
                    break;
            }
            return user.ToList();

        }

        [HttpPut]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword(int id, string password)
        {
            try
            {
                int userId = id;
                var pwd = password;

                var user = _context.Users.FirstOrDefault(u => u.UserId == userId);
                user.Password = pwd;
                await _context.SaveChangesAsync();
                return Ok(user);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
