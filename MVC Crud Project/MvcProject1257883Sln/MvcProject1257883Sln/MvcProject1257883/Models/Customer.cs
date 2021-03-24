using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcProject1257883.Models
{
    public partial class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public System.DateTime Date { get; set; }
        public string ImageName { get; set; }
        public string ImageURL { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public bool IsActive { get; set; }
        public int DistrictId { get; set; }
        public virtual District District { get; set; }
    }
}