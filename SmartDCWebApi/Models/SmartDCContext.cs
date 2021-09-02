using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDCWebApi.Models
{
    public partial class SmartDCContext : DbContext
    {
        public SmartDCContext(DbContextOptions<SmartDCContext> options)
           : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
    }
}
