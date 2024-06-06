using BussinessLayer.Concrate;
using DataAccessLayer.Concrate;
using DataAccessLayer.Concrate.EntityFramework;
using DataAccessLayer.Concrete;
using EntityLayer.Entities;
using LearnerProjectApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProjectApp.Controllers
{
    public class CourseRegisterController : Controller
    {
        CourseManager courseManager = new CourseManager(new EfCourseDal());
        ReviewManager rw = new ReviewManager(new EfReviewDal());
        StudentManager st = new StudentManager(new EfStudentDal());
        CourseRegisterManager cr = new CourseRegisterManager(new EfCourseRegisterDal());

      
        [HttpGet]
        public ActionResult Index(string search)
        {
            List<CourseReviewViewModel> reviewList = rw.TGetList()
                 .GroupBy(x => x.CourseId)
                 .Select(group => new CourseReviewViewModel
                 {
                     CourseId = group.Key,
                     ReviewValue = group.Average(x => x.ReviewValue)
                 }).ToList();

            if (!string.IsNullOrEmpty(search))
            {
                var courseList = courseManager.GetListWtihSearch(search);
                var model = new Tuple<List<Course>, List<CourseReviewViewModel>>(courseList, reviewList);
                return PartialView(model);

            }
            else
            {
                var courseList = courseManager.TGetList().OrderByDescending(x => x.CourseName).ToList();
                var model = new Tuple<List<Course>, List<CourseReviewViewModel>>(courseList, reviewList);
                return PartialView(model);
            }
        }

        [HttpPost]
        public ActionResult Index(int id,CourseRegister courseRegister)
        {
            string user =(string)Session["studentName"];
           int userid= st.TGetList().Where(x => x.NameSurname == user).Select(x => x.StudentId).FirstOrDefault();
            courseRegister.StudentId = userid;
            courseRegister.CourseId = id;
            cr.TAdd(courseRegister);
            return RedirectToAction("Index");
        }

    }




}