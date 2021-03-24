using MvcProject1257883.Context;
using MvcProject1257883.Models;
using MvcProject1257883.Models.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject1257883.Controllers
{
    public class DistrictController : Controller
    {
        CustomerManagementContext db = new CustomerManagementContext();
        // GET: District
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetDistrictDetails()
        {
            var disList = db.Districts.Select( d=> new DistrictViewModel
            {
                Id = d.Id,
                DistrictName=d.DistrictName
            }).ToList();
            return Json(disList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveDataIntoDatabase(DistrictViewModel vObj)
        {
            var result = false;
            if(vObj.Id == 0)
            {
                District obj = new District();
                obj.DistrictName = vObj.DistrictName;
                db.Districts.Add(obj);
                db.SaveChanges();
                result = true;
            }
            else
            {
                District model = db.Districts.Where(d => d.Id == vObj.Id).SingleOrDefault();
                model.DistrictName = vObj.DistrictName;
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetDistrictById(int Id)
        {
            District model = db.Districts.Where(d => d.Id == Id).SingleOrDefault();
            string value = "";
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult GetDetailsDistrictRecord(int Id)
        {
            District model = db.Districts.Where(d => d.Id == Id).SingleOrDefault();
            DistrictViewModel vObj = new DistrictViewModel();
            vObj.Id = model.Id;
            vObj.DistrictName = model.DistrictName;
            return PartialView("_doctorDetails", vObj);
        }
        public JsonResult DeleteRecord(int Id)
        {
            bool result = false;
            District model = db.Districts.Where(d => d.Id == Id).SingleOrDefault();
           
            if (model != null)
            {
                db.Districts.Remove(model);
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}