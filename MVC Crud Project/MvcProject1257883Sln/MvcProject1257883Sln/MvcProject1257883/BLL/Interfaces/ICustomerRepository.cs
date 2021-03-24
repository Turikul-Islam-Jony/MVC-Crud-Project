using MvcProject1257883.Models;
using MvcProject1257883.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProject1257883.BLL.Interfaces
{
    interface ICustomerRepository
    {
        List<CustomerListViewModel> GetCustomers();
        Customer GetCustomerById(int id);
        void SaveCustomer(Customer obj);
        void UpdateCustomer(Customer obj);
        void DeleteCustomer(int id);
        List<District> GetDistricts();
    }
}
