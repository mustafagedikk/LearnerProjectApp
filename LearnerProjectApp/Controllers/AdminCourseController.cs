using BussinessLayer.Concrate;
using DataAccessLayer.Concrate;
using DataAccessLayer.Concrate.EntityFramework;
using EntityLayer.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LearnerProjectApp.Controllers
{
    public class AdminCourseController : Controller
    {
        CourseManager cm = new CourseManager(new EfCourseDal());
        CategoryManager CategoryManager = new CategoryManager(new EfCategoryDal());
        IEducatorManager em = new IEducatorManager(new EfEducatorDal());
        // GET: AdminCourse
        public ActionResult Index()
        {
            var values = cm.TGetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCourse()
        {
            var categoryList = CategoryManager.TGetList();

            List<SelectListItem> list = categoryList.Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryId.ToString()
            }).ToList();
            ViewBag.categories = list;
            var values = em.TGetList();
            List<SelectListItem> education = em.TGetList().Select(x => new SelectListItem
            {
                Text=x.NameSurname,
                Value=x.EducatorId.ToString()

            }).ToList();
            ViewBag.teacherlist = education;

            return View();

        }

        [HttpPost]
        public ActionResult AddCourse(Course course)
        {

            course.Status = true;
            cm.TAdd(course);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditCourse(int id)
        {
            var values = CategoryManager.TGetList();

            List<SelectListItem> categoryList = values.Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryId.ToString()
            }).ToList();

            ViewBag.category = categoryList;


            List<SelectListItem> Educator = em.TGetList().Select(x => new SelectListItem
            {
                Text = x.NameSurname,
                Value = x.EducatorId.ToString()
            }).ToList();
            ViewBag.teacherinformation = Educator;

            var value = cm.TGetbyId(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult EditCourse(Course course)
        {
            cm.TUpdate(course);

            return RedirectToAction("Index");


        }

        public ActionResult DeleteCourse(int id)
        {
           var values=cm.TGetbyId(id);
            values.Status = false;
            cm.TUpdate(values);
            return RedirectToAction("index");
        }

        public ActionResult PassiveCourse()
        {
            var passivecourse = cm.GetPassiveCourseList();
            return View(passivecourse);
        }
    }

}