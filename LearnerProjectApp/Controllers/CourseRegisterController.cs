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
        Context context = new Context();

        // Index metodu, hem HttpGet hem de HttpPost olarak işaretlenmiştir.
       
      
        //public ActionResult Index()
        //{
        //    List<CourseReviewViewModel> reviewList = rw.TGetList()
        //         .GroupBy(x => x.CourseId)
        //         .Select(group => new CourseReviewViewModel
        //         {
        //             CourseId = group.Key,
        //             ReviewValue = group.Average(x => x.ReviewValue)
        //         }).ToList();

            
            
        //        var courseList = courseManager.TGetList().OrderByDescending(x => x.CourseName).ToList();
        //        var model = new Tuple<List<Course>, List<CourseReviewViewModel>>(courseList, reviewList);
        //        return PartialView(model);
            
        //}
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




    }




}