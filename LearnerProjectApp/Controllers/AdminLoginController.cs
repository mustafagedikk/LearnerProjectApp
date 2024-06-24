using BussinessLayer.Concrate;
using DataAccessLayer.Concrate.EntityFramework;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProjectApp.Controllers
{
    public class AdminLoginController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
       [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            var values = adminManager.TGetList().Where(x => x.UserName == admin.UserName && x.Password == admin.Password);
            if (values!=null)
            {
                Session["admin"] = admin.NameSurname;
                return RedirectToAction("Index", "AdminDashboard");
                TempData["NameSurname"] = (string)Session["admin"];
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
                return View();
            }
        }

    }
}