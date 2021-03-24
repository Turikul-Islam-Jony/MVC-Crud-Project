using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProject1257883.Models.ViewModel
{
    public class CustomerListViewModel
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public System.DateTime Date { get; set; }
        public string ImageName { get; set; }
        public string ImageURL { get; set; }
        public string Email { get; set; }
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public string PageTitle { get; set; }
        public District District { get; set; }


    }
}