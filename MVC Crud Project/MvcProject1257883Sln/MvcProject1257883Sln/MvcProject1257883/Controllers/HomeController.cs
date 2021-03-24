using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject1257883.Controllers
{
    public class HomeController : Controller
    {
        //[Authorize(Roles =("Admin, SuperAdmin, User"))]
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}