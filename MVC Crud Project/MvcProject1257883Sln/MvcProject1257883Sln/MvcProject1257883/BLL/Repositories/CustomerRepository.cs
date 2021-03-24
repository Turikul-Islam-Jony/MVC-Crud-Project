using MvcProject1257883.BLL.Interfaces;
using MvcProject1257883.Context;
using MvcProject1257883.Models;
using MvcProject1257883.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcProject1257883.BLL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        CustomerManagementContext db = new CustomerManagementContext();

        public void DeleteCustomer(int id)
        {
            Customer delObj = GetCustomerById(id);
            db.Customers.Remove(delObj);
            db.SaveChanges();
        }

        public Customer GetCustomerById(int id)
        {
            Customer obj = db.Customers.SingleOrDefault(c => c.CustomerId == id);
            return obj;
        }

        public List<CustomerListViewModel> GetCustomers()
        {
            List<CustomerListViewModel> viewlist = new List<CustomerListViewModel>();
            viewlist = db.Customers.Select(c => new CustomerListViewModel
            {
                CustomerId = c.CustomerId,
                CustomerName = c.CustomerName,
                Date = c.Date,
                ImageName=c.ImageName,
                ImageURL=c.ImageURL,
                PageTitle="Customer List",
                DistrictName=c.District.DistrictName,
                DistrictId=c.DistrictId
            }).ToList();
            return viewlist;
        }

        public List<District> GetDistricts()
        {
            List<District> disList = db.Districts.ToList();
            return disList;
        }

        public void SaveCustomer(Customer obj)
        {
            db.Customers.Add(obj);
            db.SaveChanges();
        }

        public void UpdateCustomer(Customer obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}