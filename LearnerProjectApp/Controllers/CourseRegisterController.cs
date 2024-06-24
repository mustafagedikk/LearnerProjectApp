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
using PagedList;
using PagedList.Mvc;
namespace LearnerProjectApp.Controllers
{
    public class CourseRegisterController : Controller
    {
        CourseManager courseManager = new CourseManager(new EfCourseDal());
        ReviewManager rw = new ReviewManager(new EfReviewDal());
        StudentManager st = new StudentManager(new EfStudentDal());
        CourseRegisterManager cr = new CourseRegisterManager(new EfCourseRegisterDal());


        [HttpGet]
        public ActionResult Index(string search,int p=1)
        {
            
            if (Session["studentName"] != null)
            {
                string user = (string)Session["studentName"];
                int userId = st.TGetList().Where(x => x.NameSurname == user).Select(x => x.StudentId).FirstOrDefault();

                
                List<int> registeredCourseIds = cr.TGetList()
                                  .Where(cr => cr.StudentId == userId)
                                  .Select(cr => cr.CourseId)
                                  .ToList();

             
                List<Course> courseList;

                
                if (string.IsNullOrEmpty(search))
                {
                  
                    courseList = courseManager.TGetList().OrderByDescending(x => x.CourseName).ToList();
                }
                else
                {
                   
                    courseList = courseManager.GetListWtihSearch(search);
                }

               
                List<Course> filteredCourseList = courseList.Where(course => !registeredCourseIds.Contains(course.CourseId)).ToList();
                var pagedlistfiltercourselist = filteredCourseList.ToPagedList(p, 9);
                                                           

                
                List<CourseReviewViewModel> reviewList = rw.TGetList()
                                                             .GroupBy(x => x.CourseId)
                                                             .Select(group => new CourseReviewViewModel
                                                             {
                                                                 CourseId = group.Key,
                                                                 ReviewValue = group.Average(x => x.ReviewValue)
                                                             }).ToList();

                var model = new Tuple<IPagedList<Course>, List<CourseReviewViewModel>>(pagedlistfiltercourselist, reviewList);
                
                
                return PartialView(model);
            }
            else
            {
                
                return RedirectToAction("Login", "Account");
            }
        }







        [HttpPost]
        public ActionResult Index(int id ,CourseRegister courseRegister)
        {
            string user = (string)Session["studentName"];
            int userid = st.TGetList().Where(x => x.NameSurname == user).Select(x => x.StudentId).FirstOrDefault();

            courseRegister.CourseId = id;
            courseRegister.StudentId = userid;
            cr.TAdd(courseRegister);

            return RedirectToAction("Index");
        }


    }




}