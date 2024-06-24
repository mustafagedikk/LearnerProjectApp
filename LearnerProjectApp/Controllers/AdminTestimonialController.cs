using BussinessLayer.Concrate;
using DataAccessLayer.Concrate.EntityFramework;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProjectApp.Controllers
{
    public class AdminTestimonialController : Controller
    {
        TestimonialManager testimonialManager = new TestimonialManager(new EfTestimonialDal());
        public ActionResult Index()
        {
            var values = testimonialManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult EditTestimonial(int id)
        {
            var values = testimonialManager.TGetbyId(id);
            return View(values);
        }

        [HttpPost]

        public ActionResult EditTestimonial(Testimonial testimonial)
        {
            testimonialManager.TUpdate(testimonial);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteTestimonial(int id)
        {
            var values = testimonialManager.TGetbyId(id);
            testimonialManager.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]

        public ActionResult AddTestimonial(Testimonial testimonial)
        {
            testimonialManager.TAdd(testimonial);
            return RedirectToAction("Index");
        }
    }
}