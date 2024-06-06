using BussinessLayer.Concrate;
using DataAccessLayer.Concrate;
using DataAccessLayer.Concrate.EntityFramework;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProjectApp.Controllers
{
    public class TeacherCourseController : Controller
    {
        CourseManager CourseManager = new CourseManager(new EfCourseDal());
        CategoryManager CategoryManager = new CategoryManager(new EfCategoryDal());

        public ActionResult Index()
        {
            string username = (string)Session["teacherName"];

            var values = CourseManager.GetlistByEducatorUserName(username);
            return View(values);
        }

        public ActionResult DeleteCourse(int id)
        {
            var values = CourseManager.TGetbyId(id);
            values.Status = false;
            CourseManager.TUpdate(values);
        
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCourse(int id)
        {
            List<SelectListItem> categorylist = CategoryManager.TGetList().Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryId.ToString()
            }).ToList();

            ViewBag.categorylist = categorylist;
            

            var values = CourseManager.TGetbyId(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateCourse(Course course)
        {

            CourseManager.TUpdate(course);
            return RedirectToAction("Index");
        }

        [HttpGet]

        public ActionResult AddCourse()
        {
            List<SelectListItem> categoryList = CategoryManager.TGetList().Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryId.ToString()
            }).ToList();

            ViewBag.Coursecategorylist = categoryList;
             
            return View();
        }

        [HttpPost]

        public ActionResult AddCourse(Course course)
        {
            string user = (string)Session["teacherName"];

            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var values = CourseManager.TGetList().Where(x => x.Educator.NameSurname == user).Select(x => x.EducatorId).FirstOrDefault();

            if (values == null)
            {
                return RedirectToAction("Index", "Login");
            }

            course.EducatorId = values;
            course.Status = true;
            CourseManager.TAdd(course);

            return RedirectToAction("Index");
        }
    }
}