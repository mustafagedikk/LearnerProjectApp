using BussinessLayer.Concrate;
using DataAccessLayer.Concrate.EntityFramework;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProjectApp.Controllers
{
    public class TeacherRegisterController : Controller
    {
        IEducatorManager educatorManager = new IEducatorManager(new EfEducatorDal());
        [HttpGet]
        public ActionResult TeacherRegister()
        {
            return View();
        }

        [HttpPost]

        public ActionResult TeacherRegister(Educator educator)
        {
            educatorManager.TAdd(educator);
            return RedirectToAction("Index","Login");
        }
    }
}