using MvcProject1257883.BLL.Repositories;
using MvcProject1257883.Models;
using MvcProject1257883.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MvcProject1257883.Controllers
{
    //[Authorize(Roles = "Admin, SuperAdmin")]
    public class CustomerController : Controller
    {
        CustomerRepository repoObj = new CustomerRepository();
        // GET: Customer
        public CustomerController()
        {

        }
        public CustomerController(CustomerRepository obj)
        {
            repoObj = obj;
        }
        public ActionResult Index()
        {
            List<CustomerListViewModel> custList = repoObj.GetCustomers();
            return View("Index",custList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            CreateCustomerViewModel obj = new CreateCustomerViewModel();
            obj.DisList = repoObj.GetDistricts();
            return View(obj);
        }
        [HttpPost]
        public ActionResult AddOrEdit(CreateCustomerViewModel viewObj)
        {
            var result = false;
            string fileName = Path.GetFileNameWithoutExtension(viewObj.ImageFile.FileName);
            string extention = Path.GetExtension(viewObj.ImageFile.FileName);
            string fileWithExtention = fileName + extention;

            Customer custobj = new Customer();
            //custobj = repoObj.GetCustomerById(viewObj.CustomerId);
            custobj.CustomerName = viewObj.CustomerName;
            custobj.Date = viewObj.Date;
            custobj.DistrictId = viewObj.DistrictId;

            custobj.ImageURL = "~/Images/" + fileWithExtention;
            custobj.ImageName = fileWithExtention;
            string fileWithServerPath = Path.Combine(Server.MapPath("~/Images/" + fileName + extention));
            viewObj.ImageFile.SaveAs(fileWithServerPath);

            if(ModelState.IsValid)
            {
                if(viewObj.CustomerId==0)
                {
                    repoObj.SaveCustomer(custobj);
                    result = true;
                }
                else
                {
                    custobj.CustomerId = viewObj.CustomerId;
                    repoObj.UpdateCustomer(custobj);
                    result = true;
                }
            }
            if(result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                if(viewObj.CustomerId==0)
                {
                    CreateCustomerViewModel obj = new CreateCustomerViewModel();
                    obj.DisList = repoObj.GetDistricts();
                    return View("Create", obj);
                }
                else
                {
                    CreateCustomerViewModel obj = new CreateCustomerViewModel();
                    obj.DisList = repoObj.GetDistricts();
                    return View("Edit", obj);
                }
            }
        }
        //[Authorize(Roles = ("Admin, SuperAdmin"))]

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Customer custObj = repoObj.GetCustomerById(id);
            CreateCustomerViewModel viewobj = new CreateCustomerViewModel();
            viewobj.CustomerId = custObj.CustomerId;
            viewobj.CustomerName = custObj.CustomerName;
            viewobj.ImageName = custObj.ImageName;
            viewobj.ImageURL = custObj.ImageURL;
            viewobj.DistrictId = custObj.DistrictId;
            viewobj.Date = custObj.Date;
            viewobj.DisList = repoObj.GetDistricts();
            return View(viewobj);
        }
        //[Authorize(Roles =("Admin, SuperAdmin"))]
        [HttpGet]

        public ActionResult Delete(int id)
        {
            Customer custObj = repoObj.GetCustomerById(id);
            CreateCustomerViewModel viewobj = new CreateCustomerViewModel();
            viewobj.CustomerId = custObj.CustomerId;
            viewobj.CustomerName = custObj.CustomerName;
            viewobj.ImageName = custObj.ImageName;
            viewobj.ImageURL = custObj.ImageURL;
            viewobj.DistrictId = custObj.DistrictId;
            viewobj.Date = custObj.Date;
            
            return View(viewobj);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            Customer custObj = repoObj.GetCustomerById(id);
           if(custObj!=null)
            {
                repoObj.DeleteCustomer(custObj.CustomerId);
                return RedirectToAction("Index");
            }

            return View();
        }


        public PartialViewResult Details(int CustomerId)
        {
            Customer custObj = repoObj.GetCustomerById(CustomerId);
            CustomerListViewModel viewobj = new CustomerListViewModel();
            viewobj.CustomerId = custObj.CustomerId;
            viewobj.CustomerName = custObj.CustomerName;
            viewobj.ImageName = custObj.ImageName;
            viewobj.ImageURL = custObj.ImageURL;
            viewobj.DistrictId = custObj.DistrictId;
            viewobj.Date = custObj.Date;
            return PartialView("_DetailsRecord", viewobj);
        }
        public ActionResult AjaxOption()
        {
            return View();
        }

        public PartialViewResult AllCustomers()
        {
            Thread.Sleep(3000);
            List<CustomerListViewModel> custList = repoObj.GetCustomers();
            return PartialView("_CustomerList", custList);
        }

        public PartialViewResult AllCustomersDesc()
        {
            Thread.Sleep(3000);
            List<CustomerListViewModel> custList = repoObj.GetCustomers();
            return PartialView("_CustomerList", custList.OrderByDescending(c => c.CustomerName));
        }

        public PartialViewResult AllCustomersAsc()
        {
            Thread.Sleep(3000);
            List<CustomerListViewModel> custList = repoObj.GetCustomers();
            return PartialView("_CustomerList", custList.OrderBy(c => c.CustomerName));
        }
    }
}