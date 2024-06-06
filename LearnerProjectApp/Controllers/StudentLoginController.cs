using BussinessLayer.Concrate;
using DataAccessLayer.Concrate.EntityFramework;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LearnerProjectApp.Controllers
{
    public class StudentLoginController : Controller
    {
        StudentManager st = new StudentManager(new EfStudentDal());

       [HttpGet]
        public ActionResult StudentLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult StudentLogin(Student student)
        {
            var values = st.GetStudentValue(student);
            if (values==null)
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(student.UserName, false);

                Session["studentName"] = values.NameSurname;
                return RedirectToAction("Index","CourseRegister");
            }
            
        }


    }
}