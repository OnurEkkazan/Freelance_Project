using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance_Project.DataModel
{
    public class Context : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Connection String: Database: Customer
            optionsBuilder.UseSqlServer(@"Server=.;Database=Customer;Trusted_Connection=True;");
        }


    }
}
