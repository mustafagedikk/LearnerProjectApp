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
            // Kullanıcı oturumunu kontrol et
            if (Session["studentName"] != null)
            {
                string user = (string)Session["studentName"];
                int userId = st.TGetList().Where(x => x.NameSurname == user).Select(x => x.StudentId).FirstOrDefault();

                // Kullanıcının katıldığı kursların Id'lerini al
                List<int> registeredCourseIds = cr.TGetList()
                                  .Where(cr => cr.StudentId == userId)
                                  .Select(cr => cr.CourseId)
                                  .ToList();

                // Tüm kursları al
                List<Course> courseList;

                // Arama yapılmış mı kontrol ediyoruz
                if (string.IsNullOrEmpty(search))
                {
                    // Arama yapılmamışsa, tüm kursları getir ve sırala
                    courseList = courseManager.TGetList().OrderByDescending(x => x.CourseName).ToList();
                }
                else
                {
                    // Arama yapılmışsa, arama sonuçlarına göre filtrelenmiş kursları getir
                    courseList = courseManager.GetListWtihSearch(search);
                }

                // Kullanıcının katılmadığı kursları filtrele
                List<Course> filteredCourseList = courseList.Where(course => !registeredCourseIds.Contains(course.CourseId))
                                                            .ToList();

                // Kurs incelemelerini al
                List<CourseReviewViewModel> reviewList = rw.TGetList()
                                                             .GroupBy(x => x.CourseId)
                                                             .Select(group => new CourseReviewViewModel
                                                             {
                                                                 CourseId = group.Key,
                                                                 ReviewValue = group.Average(x => x.ReviewValue)
                                                             }).ToList();

                var model = new Tuple<List<Course>, List<CourseReviewViewModel>>(filteredCourseList, reviewList);
                return PartialView(model);
            }
            else
            {
                // Oturum açılmamışsa, uygun bir yönlendirme yapabilirsiniz
                // Örneğin:
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