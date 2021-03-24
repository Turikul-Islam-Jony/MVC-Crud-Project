using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProject1257883.Models
{
    public class tblRole
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public int UserId { get; set; }
        public virtual tblUser TblUsers { get; set; }
    }
}