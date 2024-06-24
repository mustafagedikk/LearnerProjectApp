using BussinessLayer.Concrate;
using DataAccessLayer.Concrate.EntityFramework;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LearnerProjectApp.Controllers
{
    public class LoginController : Controller
    {
        IEducatorManager em = new IEducatorManager(new EfEducatorDal());


        [HttpGet]
        public ActionResult Index()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Index(Educator entity )
        {
            var values = em.GetEducatorvalue(entity);
            if (values ==null)
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(values.UserName, false);
                Session["teacherName"] = values.NameSurname;
                
               return RedirectToAction("Index", "TeacherCourse");
                
            }
           
        }
    }
}