using BussinessLayer.Concrate;
using DataAccessLayer.Concrate;
using DataAccessLayer.Concrate.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProjectApp.Controllers
{
    public class AdminDashboardController : Controller
    {
        CourseManager cm = new CourseManager(new EfCourseDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        ClassroomManager cs = new ClassroomManager(new EfClassroomDal());
          StudentManager st = new StudentManager(new EfStudentDal());
        // GET: AdminDashboard
        public ActionResult Index()
        {
            ViewBag.CourseCount = cm.CourseCount();
            ViewBag.CategoryCount = categoryManager.CategoryCount();
            ViewBag.ClassroomCount = cs.ClassroomCount();
            ViewBag.CoursePriceTop = cm.CoursePriceExpencive();
            ViewBag.StudentCount = st.GetStudentCount();
            ViewBag.ExpenciveCourseName = cm.ExpenciveCourseName();
            return View();
        }
    }
}