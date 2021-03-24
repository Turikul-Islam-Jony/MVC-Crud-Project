using System;
using System.ComponentModel.DataAnnotations;

namespace MvcProject1257883.Models.ViewModel
{
    internal class MyCustomeValidationAttribute : RangeAttribute
    {
        public MyCustomeValidationAttribute(int min): base(min, 30) { }
    }
}