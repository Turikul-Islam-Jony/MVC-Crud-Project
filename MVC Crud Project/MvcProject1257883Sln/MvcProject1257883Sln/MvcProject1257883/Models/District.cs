using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcProject1257883.Models
{
    public partial class District
    {
        public District()
        {
            this.Customers = new HashSet<Customer>();
        }
        [Key]
        public int Id { get; set; }
        public string DistrictName { get; set; }
       
        public virtual ICollection<Customer> Customers { get; set; }
    }
}