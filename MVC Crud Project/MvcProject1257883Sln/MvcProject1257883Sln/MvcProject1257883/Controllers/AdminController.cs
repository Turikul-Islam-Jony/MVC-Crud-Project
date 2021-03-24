using MvcProject1257883.Context;
using MvcProject1257883.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject1257883.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult CreateRole()
        {
            using (var _context = new CustomerManagementContext())
            {
                List<tblUser> userList = _context.TblUsers.ToList();
                ViewBag.Users = new SelectList(userList, "Id", "UserName");
                return View();
            }
                
        }
        [HttpPost]
        public ActionResult CreateRole(tblRole obj)
        {
            using (var _context = new CustomerManagementContext())
            {
                _context.TblRoles.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

        }
        public ActionResult Index()
        {


            using (var _context = new CustomerManagementContext())
            {
                    var userRoleList = (from user in _context.TblUsers
                                        join role in _context.TblRoles
                                        on user.Id equals role.UserId
                                        select new
                                        {
                                            UserId = user.Id,
                                            RoleId = role.Id,
                                            UserName = user.UserName,
                                            RoleName = role.RoleName
                                        }).ToList();
                    List<UserRoleViewModel> list = new List<UserRoleViewModel>();
                    foreach (var item in userRoleList)
                    {
                        UserRoleViewModel obj = new UserRoleViewModel();
                        obj.RoleId = item.RoleId;
                        obj.RoleName = item.RoleName;
                        obj.Id = item.UserId;
                        obj.UserName = item.UserName;
                        list.Add(obj);
                    }
                    return View(list);
             }

            
        }
        public ActionResult Edit(int id)
        {
            using (var _context = new CustomerManagementContext())
            {
                tblRole role = _context.TblRoles.Find(id);
                List<tblUser> userList = _context.TblUsers.ToList();
                ViewBag.Users = new SelectList(userList, "Id", "UserName");
                return View(role);
            }

        }
        [HttpPost]
        public ActionResult Edit(tblRole obj)
        {
            using (var _context = new CustomerManagementContext())
            {
                bool IsExists = _context.TblRoles.Any(u => u.RoleName == obj.RoleName && u.UserId == obj.UserId);
                if (IsExists)
                {
                    tblRole role = _context.TblRoles.Find(obj.Id);
                    role.RoleName = obj.RoleName;
                    role.UserId = obj.UserId;
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    tblRole role = _context.TblRoles.Find(obj.Id);
                    List<tblUser> userList = _context.TblUsers.ToList();
                    ViewBag.Users = new SelectList(userList, "Id", "UserName");
                    ModelState.AddModelError("", "Role already exists");
                    return View();
                }



            }

        }

        public ActionResult Delete(int id)
        {
            using (var _context = new CustomerManagementContext())
            {
                tblRole role = _context.TblRoles.Find(id);
                role.TblUsers = _context.TblUsers.Find(role.UserId);
                return View(role);
            }

        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            using (var _context = new CustomerManagementContext())
            {
                tblRole role = _context.TblRoles.Find(id);
                if (role != null)
                {
                    _context.TblRoles.Remove(role);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                role.TblUsers = _context.TblUsers.Find(role.UserId);
                return View(role);
            }

        }

        public ActionResult Details(int id)
        {
            using (var _context = new CustomerManagementContext())
            {
                tblRole role = _context.TblRoles.Find(id);
                role.TblUsers = _context.TblUsers.Find(role.UserId);
                return View(role);
            }

        }

    }
}