using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class EmployeeSearchContext : DbContext
    {
        public EmployeeSearchContext (DbContextOptions<EmployeeSearchContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication1.Models.EmployeeSearch> EmployeeSearch { get; set; }
    }
}
