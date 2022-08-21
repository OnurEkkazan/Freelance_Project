using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance_Project.DataModel
{
    [Index(nameof(Customer.Mail) ,IsUnique = true)]
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(75), Required]
        public string Name { get; set; }
        [MaxLength(75), Required]
        public string Surname { get; set; }
        [MaxLength(500), Required]
        public string Address { get; set; }
        [MaxLength(100), Required]
        public string Mail { get; set; }
    }
}
