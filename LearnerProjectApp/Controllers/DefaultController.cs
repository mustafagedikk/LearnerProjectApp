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
    public class DefaultController : Controller
    {
        CourseManager courseManager = new CourseManager(new EfCourseDal());
        ReviewManager rw = new ReviewManager(new EfReviewDal());
        Context context = new Context();


        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult DefaultCoursePartial()
        {
            // Retrieve the list of course reviews grouped by CourseId and calculate the average review value
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
            //var reviewlist = context.Reviews.Where(x => x.CourseId == id).OrderByDescending(x => x.ReviewValue).Take(2).ToList();
            //ViewBag.review = reviewlist;
            var reviewList2 = rw.GetWithCourseID(id).OrderByDescending(x => x.ReviewValue).Take(2).ToList();
          
            ViewBag.review2 = reviewList2;
            return View(values);
        }
    }
}