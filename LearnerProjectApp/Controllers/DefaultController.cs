using BussinessLayer.Concrate;
using DataAccessLayer.Abstract;
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
    public class DefaultController : Controller
    {
        CourseManager courseManager = new CourseManager(new EfCourseDal());
        ReviewManager rw = new ReviewManager(new EfReviewDal());
        Context context = new Context();
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        ClassroomManager cm = new ClassroomManager(new EfClassroomDal());
        AboutManager aboutManager = new AboutManager(new EfAbautDal());
        StudentManager studentManager = new StudentManager(new EfStudentDal());
        IEducatorManager educatorManager = new IEducatorManager(new EfEducatorDal());
        TestimonialManager testimonialManager = new TestimonialManager(new EfTestimonialDal());
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult DefaultCoursePartial()
        {

            List<CourseReviewViewModel> reviewList = rw.TGetList()
                .GroupBy(x => x.CourseId)
                .Select(group => new CourseReviewViewModel
                {
                    CourseId = group.Key,
                    ReviewValue = group.Average(x => x.ReviewValue)
                }).ToList();


            var courseList = courseManager.TGetList().OrderByDescending(x => x.CourseId).Take(6).ToList();


            var model = new Tuple<List<Course>, List<CourseReviewViewModel>>(courseList, reviewList);


            return PartialView(model);
        }

        public ActionResult CourseDetails(int id)
        {
            var values = courseManager.TGetbyId(id);
           
            var reviewList2 = rw.GetWithCourseID(id).OrderByDescending(x => x.ReviewValue).Take(2).ToList();

            ViewBag.review2 = reviewList2;
            return View(values);
        }

        public PartialViewResult CategoryList()
        {

            var sortedList = categoryManager.TGetList().Take(8).ToList();
            List<CourseCategoryCountViewModel> courselistcount = courseManager.TGetList()
         .GroupBy(x => x.CategoryId)
            .Select(group => new CourseCategoryCountViewModel
         {
             categoryid = group.Key,
             Coursecount = group.Count() 
            }).ToList();

            var model = new Tuple<List<Category>, List<CourseCategoryCountViewModel>>(sortedList, courselistcount);

            return PartialView(model);
        }

        public PartialViewResult Classroom()
        {
            var values = cm.TGetList().Take(6).ToList();
            return PartialView(values);
        }

        public PartialViewResult AboutUs()
        {
            var values = aboutManager.TGetList();
            int studentCount = studentManager.TGetList().Count(x => x.StudentId != null);
            ViewBag.studentcount = studentCount;
            var eduvatorvalues = educatorManager.TGetList().Count(x => x.EducatorId != null);
            ViewBag.educatorcount = eduvatorvalues;
            var coursevalues = courseManager.TGetList().Count(x => x.CourseId != null);
            ViewBag.coursecount = coursevalues;
            return PartialView(values);
        }

        public PartialViewResult Testimonial()
        {
            var values = testimonialManager.TGetList();
            return PartialView(values);
        }
    }
}