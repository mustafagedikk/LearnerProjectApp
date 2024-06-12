using BussinessLayer.Concrate;
using DataAccessLayer.Concrate;
using DataAccessLayer.Concrate.EntityFramework;
using EntityLayer.Entities;
using LearnerProjectApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProjectApp.Controllers
{
    public class StudentCourseController : Controller
    {
        CourseManager courseManager = new CourseManager(new EfCourseDal());
        StudentManager studentManager = new StudentManager(new EfStudentDal());
        CourseRegisterManager courseRegisterManager = new CourseRegisterManager(new EfCourseRegisterDal());
        ReviewManager rw = new ReviewManager(new EfReviewDal());
        CourseVideoManager courseVideoManager = new CourseVideoManager(new EfCourseVideoDal());
        [HttpGet]
        public ActionResult Index()
        {
            string username = (string)Session["studentName"];
            var studentvalue = studentManager.TGetList().Where(x => x.NameSurname == username).Select(x => x.StudentId).FirstOrDefault();


            var courselist = courseManager.TGetList();

            List<int> mycourselistnumber = courseRegisterManager.TGetList().Where(x => x.StudentId == studentvalue).Select(x => x.CourseId).ToList();

            List<Course> mycourselist = courseManager.TGetList().Where(course => mycourselistnumber.Contains(course.CourseId)).ToList();

            List<CourseReviewViewModel> reviewList = rw.TGetList()
                                                            .GroupBy(x => x.CourseId)
                                                            .Select(group => new CourseReviewViewModel
                                                            {
                                                                CourseId = group.Key,
                                                                ReviewValue = group.Average(x => x.ReviewValue)
                                                            }).ToList();

            var model = new Tuple<List<Course>, List<CourseReviewViewModel>>(mycourselist, reviewList);
            return PartialView(model);

            
        }

        public ActionResult MyCourseVideoList(int id)
        {
            var values = courseVideoManager.GetListMyCourseVideowithId(id);

            return View(values);
        }

    }
}