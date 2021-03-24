using MvcProject1257883.Context;
using MvcProject1257883.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProject1257883.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(tblUser obj)
        {
            using (var _context = new CustomerManagementContext())
            {
                bool isvalid = _context.TblUsers.Any(u => u.UserName == obj.UserName && u.UserPassword == obj.UserPassword);
                if(isvalid)
                {
                    FormsAuthentication.SetAuthCookie(obj.UserName, false);
                    return RedirectToAction("Index", "Home");
                }
                
            else
                {

                    ModelState.AddModelError("", "Invalid user information");
                    return View();
                }
            }


        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(tblUser obj)
        {
            using (var _context = new CustomerManagementContext())
            {
                bool isExists =!_context.TblUsers.Any(u => u.UserName == obj.UserName);
                if(isExists)
                {
                    _context.TblUsers.Add(obj);
                    _context.SaveChanges();
                    int count = _context.TblUsers.Count();
                    if(count==1)
                    {
                        return RedirectToAction("CreateRole", "Admin");
                    }
                    return View("Login");
                }
                else
                {
                    ModelState.AddModelError("", "User already exists");
                    return View();
                }
            }
            
               
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}