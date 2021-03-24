using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcProject1257883.Models.ViewModel
{
    public class CreateCustomerViewModel
    {
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Customer name required")]
        [DataType(DataType.Text)]
        [StringLength(30, ErrorMessage = "Name must be within 30 char")]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Create Date required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Create Date")]
        public System.DateTime Date { get; set; }
        [Display(Name = "Image Name")]
        public string ImageName { get; set; }
        [Display(Name = "Image Url")]
        public string ImageURL { get; set; }
        [Required]
        [RegularExpression(@"^[\w-+\._\+%]+@(?:[\w_]+\.)+[\w]{2,6}$", ErrorMessage = "It must be gmail address ")]
        public string Email { get; set; }
        [System.ComponentModel.DataAnnotations.Compare("Email", ErrorMessage = "Mismatched email address")]
        public string ConfirmEmail { get; set; }
        [MyCustomeValidation(20, ErrorMessage = "Age must be within 20-30")]
        public int Age { get; set; }
        public bool IsActive { get; set; }
        public int DistrictId { get; set; }
        public string PageTitle { get; set; }
        public List<District> DisList { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        public virtual District District { get; set; }
    }
}