using MvcProject1257883.Context;
using MvcProject1257883.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject1257883.Controllers
{
    public class DivisionController : Controller
    {

        // GET: Division
        public ActionResult Index()
        {
            using (var _context = new CustomerManagementContext())
            {
                List<Division> list = _context.Divisions.ToList();
                return View(list);
            }
                
        }
        public JsonResult InsertDivision(List<Division> divisions)
        {
            int insertRecords = 0;
            using (var _context = new CustomerManagementContext())
            {
                _context.Database.ExecuteSqlCommand("TRUNCATE TABLE [divisions]");
                if(divisions == null)
                {
                    divisions = new List<Division>();
                }
                foreach (var item in divisions)
                {
                    _context.Divisions.Add(item);
                }
                insertRecords = _context.SaveChanges();
                return Json(insertRecords);
            }
        }
    }
}