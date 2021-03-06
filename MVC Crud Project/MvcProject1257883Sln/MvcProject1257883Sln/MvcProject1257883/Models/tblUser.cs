using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcProject1257883.Models
{
    public class tblUser
    {
        public tblUser()
        {
            this.TblRoles = new HashSet<tblRole>();
            
        }
        public int Id { get; set; }
        [Display(Name ="User Name")]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }
        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
        public string FullName { get; set; }
        public virtual ICollection<tblRole> TblRoles { get; set; }
    }
}