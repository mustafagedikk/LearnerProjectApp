using BussinessLayer.Concrate;
using DataAccessLayer.Concrate;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProjectApp.Controllers
{
    public class AdminAboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAbautDal()); 
        public ActionResult Index()
        {
            var values = aboutManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult EditAbout(int id)
        {
            var values = aboutManager.TGetbyId(id);
            return View(values);
        }

         [HttpPost]
         public ActionResult EditAbout(About about)
        {
            aboutManager.TUpdate(about);
            return RedirectToAction("Index");
        }
    }
}